namespace Flappy_Bird_Windows.Forms;

public sealed partial class SingleButtonForm : Form
{
    public SingleButtonForm()
    {
        InitializeComponent();

        ButtonPixelBox.Location = new Point(0, 0);
        ButtonPixelBox.Size = new Size(ClientSize.Width, ClientSize.Height);
        TopMost = Program.ProgramConfig.AlwaysOnTop;
        BackColor = Color.FromArgb(255, 85, 48, 0);
    }
}
