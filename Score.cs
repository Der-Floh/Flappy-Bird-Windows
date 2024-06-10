namespace Flappy_Bird_Windows;

public partial class Score : Form
{
    public int ScoreValue { get; set; }

    public Score()
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());

        InitializeComponent();
    }

    public void AddScore()
    {
        ScoreValue++;
        ScoreLabel.Text = ScoreValue.ToString();
    }
}
