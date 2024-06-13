﻿namespace Flappy_Bird_Windows.Forms;

public sealed partial class PipeBottomForm : Form
{
    public PipeBottomForm()
    {
        InitializeComponent();

        TopMost = Program.GameplayConfig.AlwaysOnTop;
    }

    public void MovePipe()
    {
        Location = new Point(Location.X - Program.GameplayConfig.PipeMoveSpeed, Location.Y);
        if (Location.X + Program.GameplayConfig.PipeDespawnOffset < 0)
            Close();
    }
}
