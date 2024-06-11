namespace Flappy_Bird_Windows;

public partial class PipeTop : Form
{
    public PipeTop()
    {
        InitializeComponent();
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - Program.GamePlayConfig.PipeMoveSpeed, Location.Y);
        if (Location.X + Width < 0)
            Close();
    }
}
