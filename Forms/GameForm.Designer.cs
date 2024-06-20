namespace Flappy_Bird_Windows.Forms;

sealed partial class GameForm
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
        PipeSpawnTimer = new System.Windows.Forms.Timer(components);
        PipeMoveTimer = new System.Windows.Forms.Timer(components);
        BirdMoveTimer = new System.Windows.Forms.Timer(components);
        BirdMovePreviewTimer = new System.Windows.Forms.Timer(components);
        SuspendLayout();
        // 
        // PipeSpawnTimer
        // 
        PipeSpawnTimer.Interval = 3000;
        PipeSpawnTimer.Tick += PipeSpawnTimer_Tick;
        // 
        // PipeMoveTimer
        // 
        PipeMoveTimer.Interval = 10;
        PipeMoveTimer.Tick += PipeMoveTimer_Tick;
        // 
        // BirdMoveTimer
        // 
        BirdMoveTimer.Enabled = true;
        BirdMoveTimer.Interval = 10;
        BirdMoveTimer.Tick += BirdMoveTimer_Tick;
        // 
        // BirdMovePreviewTimer
        // 
        BirdMovePreviewTimer.Interval = 10;
        BirdMovePreviewTimer.Tick += BirdMovePreviewTimer_Tick;
        // 
        // GameForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(800, 450);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "GameForm";
        ShowInTaskbar = false;
        Text = "Game";
        WindowState = FormWindowState.Minimized;
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Timer PipeSpawnTimer;
    private System.Windows.Forms.Timer PipeMoveTimer;
    private System.Windows.Forms.Timer BirdMoveTimer;
    private System.Windows.Forms.Timer BirdMovePreviewTimer;
}