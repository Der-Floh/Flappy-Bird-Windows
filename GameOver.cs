namespace Flappy_Bird_Windows;

public partial class GameOver : Form
{
    public event EventHandler? RestartEvent;

    public GameOver()
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());

        InitializeComponent();
    }

    private void RestartButton_Click(object sender, EventArgs e)
    {
        RestartEvent?.Invoke(this, EventArgs.Empty);
    }
}
