using Flappy_Bird_Windows.Data.Config;

using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class TapToStartForm : Form
{
    public TapToStartForm(IOptions<ProgramConfig> programOptions)
    {
        InitializeComponent();

        TopToStartPixelBox.Location = new Point(0, MainMenuStrip.ClientSize.Height);
        TopToStartPixelBox.Size = new Size(ClientSize.Width, ClientSize.Height - MainMenuStrip.ClientSize.Height);
        TopMost = programOptions.Value.AlwaysOnTop;
    }

    private void TapToStartForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
}
