namespace Flappy_Bird_Windows.Forms;

public sealed partial class PipeBottomForm : Form
{
    private readonly int _pipeMoveSpeed;
    private readonly int _pipeDespawnOffset;

    public PipeBottomForm(bool alwaysOnTop, int pipeMoveSpeed, int pipeDespawnOffset)
    {
        _pipeMoveSpeed = pipeMoveSpeed;
        _pipeDespawnOffset = pipeDespawnOffset;

        InitializeComponent();

        PipeTopPixelBox.Location = new Point(0, 0);
        PipeTopPixelBox.Size = new Size(ClientSize.Width, ClientSize.Width);
        PipeMiddlePixelBox.Location = new Point(0, PipeTopPixelBox.Height);
        PipeMiddlePixelBox.Size = new Size(ClientSize.Width, ClientSize.Height - PipeTopPixelBox.Height);
        TopMost = alwaysOnTop;
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - _pipeMoveSpeed, Location.Y);
        if (Location.X + _pipeDespawnOffset < 0)
            Close();
    }
}
