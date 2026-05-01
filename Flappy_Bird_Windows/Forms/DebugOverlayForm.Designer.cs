namespace Flappy_Bird_Windows.Forms;

partial class DebugOverlayForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.FpsLabel = new System.Windows.Forms.Label();
            this.CountsLabel = new System.Windows.Forms.Label();
            this.MoveLabel = new System.Windows.Forms.Label();
            this.PhysLabel = new System.Windows.Forms.Label();
            this.CollLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Interval = 200;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // FpsLabel
            // 
            this.FpsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FpsLabel.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.FpsLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.FpsLabel.Location = new System.Drawing.Point(0, 0);
            this.FpsLabel.Name = "FpsLabel";
            this.FpsLabel.Size = new System.Drawing.Size(345, 22);
            this.FpsLabel.TabIndex = 4;
            this.FpsLabel.Text = "FPS:      --";
            // 
            // CountsLabel
            // 
            this.CountsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CountsLabel.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.CountsLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.CountsLabel.Location = new System.Drawing.Point(0, 22);
            this.CountsLabel.Name = "CountsLabel";
            this.CountsLabel.Size = new System.Drawing.Size(345, 22);
            this.CountsLabel.TabIndex = 3;
            this.CountsLabel.Text = "Pipes: --   Birds: --";
            // 
            // MoveLabel
            // 
            this.MoveLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MoveLabel.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.MoveLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.MoveLabel.Location = new System.Drawing.Point(0, 44);
            this.MoveLabel.Name = "MoveLabel";
            this.MoveLabel.Size = new System.Drawing.Size(345, 22);
            this.MoveLabel.TabIndex = 2;
            this.MoveLabel.Text = "Move:  -- ms";
            // 
            // PhysLabel
            // 
            this.PhysLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PhysLabel.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.PhysLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.PhysLabel.Location = new System.Drawing.Point(0, 66);
            this.PhysLabel.Name = "PhysLabel";
            this.PhysLabel.Size = new System.Drawing.Size(345, 22);
            this.PhysLabel.TabIndex = 1;
            this.PhysLabel.Text = "Phys:  -- ms";
            // 
            // CollLabel
            // 
            this.CollLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CollLabel.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.CollLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.CollLabel.Location = new System.Drawing.Point(0, 88);
            this.CollLabel.Name = "CollLabel";
            this.CollLabel.Size = new System.Drawing.Size(345, 22);
            this.CollLabel.TabIndex = 0;
            this.CollLabel.Text = "Coll:  -- ms";
            // 
            // DebugOverlayForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(345, 110);
            this.Controls.Add(this.CollLabel);
            this.Controls.Add(this.PhysLabel);
            this.Controls.Add(this.MoveLabel);
            this.Controls.Add(this.CountsLabel);
            this.Controls.Add(this.FpsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugOverlayForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Debug";
            this.ResumeLayout(false);

    }

    private System.Windows.Forms.Timer RefreshTimer = null!;
    private Label FpsLabel = null!;
    private Label CountsLabel = null!;
    private Label MoveLabel = null!;
    private Label PhysLabel = null!;
    private Label CollLabel = null!;
}
