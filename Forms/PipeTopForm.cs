namespace Flappy_Bird_Windows.Forms;

public sealed partial class PipeTopForm : Form
{
    public PipeTopForm()
    {
        InitializeComponent();

        TopMost = Program.ProgramConfig.AlwaysOnTop;
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - Program.GameplayConfig.PipeMoveSpeed, Location.Y);
        if (Location.X + Program.GameplayConfig.PipeDespawnOffset < 0)
            Close();
    }
}
