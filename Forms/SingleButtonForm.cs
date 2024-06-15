namespace Flappy_Bird_Windows.Forms;

public sealed partial class SingleButtonForm : Form
{
    public SingleButtonForm()
    {
        InitializeComponent();

        TopMost = Program.ProgramConfig.AlwaysOnTop;
        BackColor = Color.FromArgb(255, 85, 48, 0);
    }
}
