namespace Flappy_Bird_Windows.Forms;

partial class ConfigForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
        SaveButton = new Button();
        CloseButton = new Button();
        ConfigsTabControl = new TabControl();
        ResetButton = new Button();
        SuspendLayout();
        // 
        // SaveButton
        // 
        SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        SaveButton.Cursor = Cursors.Hand;
        SaveButton.Enabled = false;
        SaveButton.Location = new Point(782, 674);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new Size(104, 43);
        SaveButton.TabIndex = 0;
        SaveButton.Text = "Save";
        SaveButton.UseVisualStyleBackColor = true;
        SaveButton.Click += SaveButton_Click;
        // 
        // CloseButton
        // 
        CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        CloseButton.Cursor = Cursors.Hand;
        CloseButton.Location = new Point(892, 674);
        CloseButton.Name = "CloseButton";
        CloseButton.Size = new Size(104, 43);
        CloseButton.TabIndex = 1;
        CloseButton.Text = "Close";
        CloseButton.UseVisualStyleBackColor = true;
        // 
        // ConfigsTabControl
        // 
        ConfigsTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        ConfigsTabControl.Location = new Point(12, 12);
        ConfigsTabControl.Name = "ConfigsTabControl";
        ConfigsTabControl.SelectedIndex = 0;
        ConfigsTabControl.Size = new Size(984, 656);
        ConfigsTabControl.TabIndex = 2;
        // 
        // ResetButton
        // 
        ResetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        ResetButton.Cursor = Cursors.Hand;
        ResetButton.Location = new Point(12, 674);
        ResetButton.Name = "ResetButton";
        ResetButton.Size = new Size(104, 43);
        ResetButton.TabIndex = 3;
        ResetButton.Text = "Reset";
        ResetButton.UseVisualStyleBackColor = true;
        ResetButton.Click += ResetButton_Click;
        // 
        // ConfigForm
        // 
        AcceptButton = SaveButton;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        CancelButton = CloseButton;
        ClientSize = new Size(1008, 729);
        Controls.Add(ResetButton);
        Controls.Add(ConfigsTabControl);
        Controls.Add(CloseButton);
        Controls.Add(SaveButton);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "ConfigForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Config";
        FormClosing += ConfigForm_FormClosing;
        ResumeLayout(false);
    }

    #endregion

    private Button SaveButton;
    private Button CloseButton;
    private TabControl ConfigsTabControl;
    private Button ResetButton;
}