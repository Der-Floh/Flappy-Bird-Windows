﻿using Flappy_Bird_Windows.Helper;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class ScoreForm : Form
{
    public int ScoreValue { get; set; }

    public ScoreForm()
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());

        InitializeComponent();

        TopMost = Program.GameplayConfig.AlwaysOnTop;

        ScoreLabel.Font = new Font(Program.Fonts.Families[0], ScoreLabel.Font.Size);
    }

    public void AddScore()
    {
        ScoreValue++;
        ScoreLabel.Text = ScoreValue.ToString();
    }
}