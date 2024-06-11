namespace Flappy_Bird_Windows;

public partial class PipeBottom : Form
{
    public PipeBottom()
    {
        InitializeComponent();
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - Program.GameplayConfig.PipeMoveSpeed, Location.Y);
        if (Location.X + Program.GameplayConfig.PipeDespawnOffset < 0)
            Close();
    }
}
