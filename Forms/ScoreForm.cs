namespace Flappy_Bird_Windows.Forms;

public sealed partial class ScoreForm : Form
{
    public int ScoreValue { get => _scoreValue; set { _scoreValue = value; UpdateScore(); } }
    private int _scoreValue;

    public ScoreForm()
    {
        InitializeComponent();

        TopMost = Program.ProgramConfig.AlwaysOnTop;

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
