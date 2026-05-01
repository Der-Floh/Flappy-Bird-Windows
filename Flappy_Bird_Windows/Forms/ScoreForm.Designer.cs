namespace Flappy_Bird_Windows.Forms;

sealed partial class ScoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreForm));
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreLabel.Font = new System.Drawing.Font("Segoe UI", 28F);
            this.ScoreLabel.Location = new System.Drawing.Point(0, 0);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(122, 53);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "0";
            this.ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(120, 52);
            this.Controls.Add(this.ScoreLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Score";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScoreForm_FormClosing);
            this.ResumeLayout(false);

    }

    #endregion

    private Label ScoreLabel;
}