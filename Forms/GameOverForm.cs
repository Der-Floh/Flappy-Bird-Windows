namespace Flappy_Bird_Windows.Forms;

public sealed partial class GameOverForm : Form
{
    public event EventHandler? RestartEvent;

    public GameOverForm()
    {
        InitializeComponent();

        TopMost = Program.ProgramConfig.AlwaysOnTop;
        BackColor = Color.FromArgb(255, 234, 252, 219);
    }

    private void RestartButton_Click(object sender, EventArgs e)
    {
        RestartEvent?.Invoke(this, EventArgs.Empty);
    }

    private void GameOverForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
}
