namespace Flappy_Bird_Windows;

public partial class PipeTop : Form
{
    public int MoveSpeed = 5;

    public PipeTop()
    {
        InitializeComponent();
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - MoveSpeed, Location.Y);
        if (Location.X + Width < 0)
            Close();
    }
}
