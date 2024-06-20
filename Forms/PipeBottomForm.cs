namespace Flappy_Bird_Windows.Forms;

public sealed partial class PipeBottomForm : Form
{
    public PipeBottomForm()
    {
        InitializeComponent();

        PipeTopPixelBox.Location = new Point(0, 0);
        PipeTopPixelBox.Size = new Size(ClientSize.Width, ClientSize.Width);
        PipeMiddlePixelBox.Location = new Point(0, PipeTopPixelBox.Height);
        PipeMiddlePixelBox.Size = new Size(ClientSize.Width, ClientSize.Height - PipeTopPixelBox.Height);
        TopMost = Program.ProgramConfig.AlwaysOnTop;
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - Program.GameplayConfig.PipeMoveSpeed, Location.Y);
        if (Location.X + Program.GameplayConfig.PipeDespawnOffset < 0)
            Close();
    }
}
