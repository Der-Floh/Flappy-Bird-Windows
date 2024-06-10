namespace Flappy_Bird_Windows;

partial class Game
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        GameTimer = new System.Windows.Forms.Timer(components);
        PipeSpawnTimer = new System.Windows.Forms.Timer(components);
        PipeMoveTimer = new System.Windows.Forms.Timer(components);
        BirdMoveTimer = new System.Windows.Forms.Timer(components);
        SuspendLayout();
        // 
        // GameTimer
        // 
        GameTimer.Enabled = true;
        GameTimer.Tick += GameTimer_Tick;
        // 
        // PipeSpawnTimer
        // 
        PipeSpawnTimer.Enabled = true;
        PipeSpawnTimer.Interval = 3000;
        PipeSpawnTimer.Tick += PipeSpawnTimer_Tick;
        // 
        // PipeMoveTimer
        // 
        PipeMoveTimer.Enabled = true;
        PipeMoveTimer.Interval = 10;
        PipeMoveTimer.Tick += PipeMoveTimer_Tick;
        // 
        // BirdMoveTimer
        // 
        BirdMoveTimer.Enabled = true;
        BirdMoveTimer.Interval = 10;
        BirdMoveTimer.Tick += BirdMoveTimer_Tick;
        // 
        // Game
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Game";
        ShowInTaskbar = false;
        Text = "Game";
        WindowState = FormWindowState.Minimized;
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Timer GameTimer;
    private System.Windows.Forms.Timer PipeSpawnTimer;
    private System.Windows.Forms.Timer PipeMoveTimer;
    private System.Windows.Forms.Timer BirdMoveTimer;
}