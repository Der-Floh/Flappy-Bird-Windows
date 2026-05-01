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
        this.components = new System.ComponentModel.Container();
        this.PipeSpawnTimer = new System.Windows.Forms.Timer(this.components);
        this.PipeMoveTimer = new System.Windows.Forms.Timer(this.components);
        this.BirdMoveTimer = new System.Windows.Forms.Timer(this.components);
        this.BirdMovePreviewTimer = new System.Windows.Forms.Timer(this.components);
        this.CollisionTimer = new System.Windows.Forms.Timer(this.components);
        this.SuspendLayout();
        // 
        // PipeSpawnTimer
        // 
        this.PipeSpawnTimer.Interval = 3000;
        this.PipeSpawnTimer.Tick += new System.EventHandler(this.PipeSpawnTimer_Tick);
        // 
        // PipeMoveTimer
        // 
        this.PipeMoveTimer.Interval = 10;
        this.PipeMoveTimer.Tick += new System.EventHandler(this.PipeMoveTimer_Tick);
        // 
        // BirdMoveTimer
        // 
        this.BirdMoveTimer.Enabled = true;
        this.BirdMoveTimer.Interval = 10;
        this.BirdMoveTimer.Tick += new System.EventHandler(this.BirdMoveTimer_Tick);
        // 
        // BirdMovePreviewTimer
        // 
        this.BirdMovePreviewTimer.Interval = 10;
        this.BirdMovePreviewTimer.Tick += new System.EventHandler(this.BirdMovePreviewTimer_Tick);
        // 
        // CollisionTimer
        // 
        this.CollisionTimer.Interval = 20;
        this.CollisionTimer.Tick += new System.EventHandler(this.CollisionTimer_Tick);
        // 
        // GameForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "GameForm";
        this.ShowInTaskbar = false;
        this.Text = "Game";
        this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
        this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Timer PipeSpawnTimer;
    private System.Windows.Forms.Timer PipeMoveTimer;
    private System.Windows.Forms.Timer BirdMoveTimer;
    private System.Windows.Forms.Timer BirdMovePreviewTimer;
    private System.Windows.Forms.Timer CollisionTimer;
}