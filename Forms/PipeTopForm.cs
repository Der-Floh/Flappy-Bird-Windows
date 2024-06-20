namespace Flappy_Bird_Windows.Forms;

public sealed partial class PipeTopForm : Form
{
    public PipeTopForm()
    {
        InitializeComponent();

        PipeBottomPixelBox.Location = new Point(0, ClientSize.Height - ClientSize.Width);
        PipeBottomPixelBox.Size = new Size(ClientSize.Width, ClientSize.Width);
        PipeMiddlePixelBox.Location = new Point(0, 0);
        PipeMiddlePixelBox.Size = new Size(ClientSize.Width, ClientSize.Height - PipeBottomPixelBox.Height);
        TopMost = Program.ProgramConfig.AlwaysOnTop;
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - Program.GameplayConfig.PipeMoveSpeed, Location.Y);
        if (Location.X + Program.GameplayConfig.PipeDespawnOffset < 0)
            Close();
    }
}
