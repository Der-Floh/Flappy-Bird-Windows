using Flappy_Bird_Windows.Data.Config;

using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class SingleButtonForm : Form
{
    public SingleButtonForm(IOptions<ProgramConfig> programOptions)
    {
        InitializeComponent();

        ButtonPixelBox.Location = new Point(0, 0);
        ButtonPixelBox.Size = new Size(ClientSize.Width, ClientSize.Height);
        TopMost = programOptions.Value.AlwaysOnTop;
        BackColor = Color.FromArgb(255, 85, 48, 0);
    }
}
