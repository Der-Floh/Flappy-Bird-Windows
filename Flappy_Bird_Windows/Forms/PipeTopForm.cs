namespace Flappy_Bird_Windows.Forms;

public sealed partial class PipeTopForm : Form
{
    private readonly int _pipeMoveSpeed;
    private readonly int _pipeDespawnOffset;

    public PipeTopForm(bool alwaysOnTop, int pipeMoveSpeed, int pipeDespawnOffset)
    {
        _pipeMoveSpeed = pipeMoveSpeed;
        _pipeDespawnOffset = pipeDespawnOffset;

        InitializeComponent();

        PipeBottomPixelBox.Location = new Point(0, ClientSize.Height - ClientSize.Width);
        PipeBottomPixelBox.Size = new Size(ClientSize.Width, ClientSize.Width);
        PipeMiddlePixelBox.Location = new Point(0, 0);
        PipeMiddlePixelBox.Size = new Size(ClientSize.Width, ClientSize.Height - PipeBottomPixelBox.Height);
        TopMost = alwaysOnTop;
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - _pipeMoveSpeed, Location.Y);
        if (Location.X + _pipeDespawnOffset < 0)
            Close();
    }
}
