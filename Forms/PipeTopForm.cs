namespace Flappy_Bird_Windows.Forms;

public sealed partial class PipeTopForm : Form
{
    public PipeTopForm()
    {
        InitializeComponent();

        TopMost = Program.ProgramConfig.AlwaysOnTop;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        base.OnPaintBackground(e);
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - Program.GameplayConfig.PipeMoveSpeed, Location.Y);
        if (Location.X + Program.GameplayConfig.PipeDespawnOffset < 0)
            Close();
    }
}
