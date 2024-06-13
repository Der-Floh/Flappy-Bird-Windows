using Flappy_Bird_Windows.Helper;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class GameOverForm : Form
{
    public event EventHandler? RestartEvent;

    public GameOverForm()
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());

        InitializeComponent();

        TopMost = Program.GameplayConfig.AlwaysOnTop;
    }

    private void RestartButton_Click(object sender, EventArgs e)
    {
        RestartEvent?.Invoke(this, EventArgs.Empty);
    }
}
