using System.Reflection;

namespace Flappy_Bird_Windows.Forms;
public partial class ConfigForm : Form
{
    public bool UnsavedChanges { get => _unsavedChanges; set { _unsavedChanges = value; SaveButton.Enabled = value; } }
    private bool _unsavedChanges;

    private readonly object[] _configObjects;
    private readonly Dictionary<PropertyInfo, object?> _defaultValues = [];
    private readonly List<PropertyInfo> _newValues = [];

    public ConfigForm(object[] configObjects)
    {
        InitializeComponent();

        TopMost = Program.ProgramConfig.AlwaysOnTop;

        _configObjects = configObjects;
        GenerateControls();
    }

    private void GenerateControls()
    {
        foreach (var configObject in _configObjects)
        {
            var tabControl = new TabPage
            {
                Text = configObject.GetType().Name
            };
            ConfigsTabControl.TabPages.Add(tabControl);
        }

        var i = 0;
        foreach (var configObject in _configObjects)
        {
            var properties = configObject.GetType().GetProperties();

            var objectTableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
                RowCount = properties.Length,
                Margin = new Padding(10)
            };

            objectTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            for (var j = 0; j < properties.Length; j++)
            {
                objectTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / properties.Length));
            }

            var rowIndex = 0;
            foreach (var property in properties)
            {
                _defaultValues.Add(property, property.GetValue(configObject));

                var configControl = CreateConfigOption(property, configObject);
                if (configControl != null)
                {
                    objectTableLayoutPanel.Controls.Add(configControl, 0, rowIndex);
                    rowIndex++;
                }
            }

            ConfigsTabControl.TabPages[i].Controls.Add(objectTableLayoutPanel);

            i++;
        }
    }

    private TableLayoutPanel? CreateConfigOption(PropertyInfo property, object configObject)
    {
        var tableLayoutPanel = new TableLayoutPanel
        {
            ColumnCount = 2,
            RowCount = 1,
            Dock = DockStyle.Fill,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            Margin = new Padding(5)
        };

        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

        Control control;
        var panel = new Panel
        {
            AutoSize = true,
        };
        var label = new Label
        {
            Text = property.Name,
            Anchor = AnchorStyles.Left | AnchorStyles.Top,
            AutoSize = true,
            Cursor = Cursors.Hand,
            Location = new Point(0, 3)
        };
        panel.Controls.Add(label);

        if (property.PropertyType == typeof(bool))
        {
            control = new CheckBox
            {
                Tag = new PropertyBinding(configObject, property),
                Text = property.Name,
                Checked = property.GetValue(configObject) as bool? ?? false,
                AutoSize = true,
                Location = new Point(0, 3),
                RightToLeft = RightToLeft.Yes,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Cursor = Cursors.Hand
            };
            (control as CheckBox)!.CheckedChanged += ControlValueChanged;
            panel.Controls.Clear();
            panel.Controls.Add(control);
        }
        else if (property.PropertyType == typeof(int))
        {
            control = new NumericUpDown
            {
                DecimalPlaces = 0,
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Tag = new PropertyBinding(configObject, property),
                Value = property.GetValue(configObject) as int? ?? 0,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            (control as NumericUpDown)!.ValueChanged += ControlValueChanged;
            label.Click += (s, e) => control.Focus();
        }
        else if (property.PropertyType == typeof(float) || property.PropertyType == typeof(double) || property.PropertyType == typeof(decimal))
        {
            control = new NumericUpDown
            {
                DecimalPlaces = 2,
                Increment = 0.5m,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Tag = new PropertyBinding(configObject, property),
                Value = Convert.ToDecimal(property.GetValue(configObject) ?? 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            (control as NumericUpDown)!.ValueChanged += ControlValueChanged;
            label.Click += (s, e) => control.Focus();
        }
        else if (property.PropertyType == typeof(string) || property.PropertyType == typeof(Keys))
        {
            control = new TextBox
            {
                Tag = new PropertyBinding(configObject, property),
                Text = property.GetValue(configObject)?.ToString(),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            (control as TextBox)!.TextChanged += ControlValueChanged;
            label.Click += (s, e) => control.Focus();
        }
        else
        {
            return null;
        }

        tableLayoutPanel.Controls.Add(panel, 0, 0);
        if (property.PropertyType != typeof(bool))
            tableLayoutPanel.Controls.Add(control, 1, 0);

        return tableLayoutPanel;
    }

    private void ControlValueChanged(object? sender, EventArgs e)
    {
        var control = sender as Control;
        if (control?.Tag is PropertyBinding binding)
        {
            var property = binding.Property;
            var configObject = binding.ConfigObject;

            try
            {
                if (control is NumericUpDown numericUpDown)
                {
                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(configObject, Convert.ToInt32(numericUpDown.Value));
                    }
                    else if (property.PropertyType == typeof(float))
                    {
                        property.SetValue(configObject, Convert.ToSingle(numericUpDown.Value));
                    }
                    else if (property.PropertyType == typeof(double))
                    {
                        property.SetValue(configObject, Convert.ToDouble(numericUpDown.Value));
                    }
                    else if (property.PropertyType == typeof(decimal))
                    {
                        property.SetValue(configObject, Convert.ToDecimal(numericUpDown.Value));
                    }
                }
                else if (control is CheckBox checkBox)
                {
                    property.SetValue(configObject, checkBox.Checked);
                }
                else if (control is TextBox textBox)
                {
                    if (property.PropertyType == typeof(Keys))
                        property.SetValue(configObject, (Keys)Enum.Parse(typeof(Keys), textBox.Text, true));
                    else
                        property.SetValue(configObject, textBox.Text);
                }

                if (_defaultValues.TryGetValue(property, out var defaultValue))
                {
                    var newValue = property.GetValue(configObject);
                    if (newValue?.Equals(defaultValue) ?? false)
                    {
                        _newValues.Remove(property);
                    }
                    else
                    {
                        var oldValue = _newValues.FirstOrDefault(x => x.Name == property.Name);
                        if (oldValue is null)
                            _newValues.Add(property);
                        else
                            oldValue.SetValue(configObject, newValue);
                    }
                    UnsavedChanges = _newValues.Count != 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting property '{property.Name}': {ex.Message}", "Apply config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        Program.SaveConfig();
        UnsavedChanges = false;
    }

    private void ResetButton_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Are you sure you want to reset the config? This cannot be undone.", "Reset Config", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            Program.ResetConfig();
            Close();
        }
    }

    private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (UnsavedChanges && MessageBox.Show("You have unsaved changes. Do you want to save the changes?", "Flappy Bird Config", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            Program.SaveConfig();
            UnsavedChanges = false;
        }
        else if (UnsavedChanges)
        {
            foreach (var configObject in _configObjects)
            {
                foreach (var property in configObject.GetType().GetProperties())
                {
                    if (_defaultValues.TryGetValue(property, out var defaultValue))
                    {
                        if (!property.GetValue(configObject)?.Equals(defaultValue) ?? false)
                            property.SetValue(configObject, defaultValue);
                    }
                }
            }
        }
    }
}

public class PropertyBinding(object configObject, PropertyInfo property)
{
    public object ConfigObject { get; } = configObject;
    public PropertyInfo Property { get; } = property;
}
