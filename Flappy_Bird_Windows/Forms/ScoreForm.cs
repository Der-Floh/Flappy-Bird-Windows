using Flappy_Bird_Windows.Data.Config;

using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class ScoreForm : Form
{
    public int ScoreValue { get; set { field = value; UpdateScore(); } }

    public ScoreForm(IOptions<ProgramConfig> programOptions)
    {
        InitializeComponent();

        ScoreLabel.Location = new Point(0, 0);
        ScoreLabel.Size = new Size(ClientSize.Width, ClientSize.Height);
        TopMost = programOptions.Value.AlwaysOnTop;

        ScoreLabel.Font = new Font(Program.Fonts.Families[0], ScoreLabel.Font.Size);
    }

    public void UpdateScore()
    {
        if (InvokeRequired)
        {
            BeginInvoke(new Action(UpdateScore));
            return;
        }
        ScoreLabel.Text = ScoreValue.ToString();
    }

    private void ScoreForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
}
