namespace Flappy_Bird_Windows.Forms;

public sealed partial class ScoreForm : Form
{
    public int ScoreValue { get; set; }

    public ScoreForm()
    {
        InitializeComponent();

        TopMost = Program.ProgramConfig.AlwaysOnTop;

        ScoreLabel.Font = new Font(Program.Fonts.Families[0], ScoreLabel.Font.Size);
    }

    public void AddScore()
    {
        ScoreValue++;
        ScoreLabel.Text = ScoreValue.ToString();
    }
}
