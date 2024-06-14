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

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        base.OnPaintBackground(e);
    }

    private void RestartButton_Click(object sender, EventArgs e)
    {
        RestartEvent?.Invoke(this, EventArgs.Empty);
    }
}
