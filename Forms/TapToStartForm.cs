﻿namespace Flappy_Bird_Windows.Forms;

public sealed partial class TapToStartForm : Form
{
    public TapToStartForm()
    {
        InitializeComponent();

        TopToStartPixelBox.Location = new Point(0, MainMenuStrip.ClientSize.Height);
        TopToStartPixelBox.Size = new Size(ClientSize.Width, ClientSize.Height - MainMenuStrip.ClientSize.Height);
        TopMost = Program.ProgramConfig.AlwaysOnTop;
    }

    private void TapToStartForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
}
