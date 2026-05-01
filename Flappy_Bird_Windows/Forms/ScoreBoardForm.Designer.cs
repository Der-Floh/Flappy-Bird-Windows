namespace Flappy_Bird_Windows.Forms;

sealed partial class ScoreBoardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreBoardForm));
            this.ScoreBoardPixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            this.NewPixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            this.MedalPixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            this.BestScoreLabel = new System.Windows.Forms.Label();
            this.CurrScoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBoardPixelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPixelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedalPixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ScoreBoardPixelBox
            // 
            this.ScoreBoardPixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreBoardPixelBox.BackColor = System.Drawing.Color.Transparent;
            this.ScoreBoardPixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.score_board;
            this.ScoreBoardPixelBox.Location = new System.Drawing.Point(0, 0);
            this.ScoreBoardPixelBox.Name = "ScoreBoardPixelBox";
            this.ScoreBoardPixelBox.Size = new System.Drawing.Size(506, 288);
            this.ScoreBoardPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScoreBoardPixelBox.TabIndex = 12;
            this.ScoreBoardPixelBox.TabStop = false;
            // 
            // NewPixelBox
            // 
            this.NewPixelBox.BackColor = System.Drawing.Color.Transparent;
            this.NewPixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.text_new;
            this.NewPixelBox.Location = new System.Drawing.Point(303, 146);
            this.NewPixelBox.Name = "NewPixelBox";
            this.NewPixelBox.Size = new System.Drawing.Size(69, 35);
            this.NewPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NewPixelBox.TabIndex = 17;
            this.NewPixelBox.TabStop = false;
            this.NewPixelBox.Visible = false;
            // 
            // MedalPixelBox
            // 
            this.MedalPixelBox.BackColor = System.Drawing.Color.Transparent;
            this.MedalPixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.medal_empty;
            this.MedalPixelBox.Location = new System.Drawing.Point(55, 98);
            this.MedalPixelBox.Name = "MedalPixelBox";
            this.MedalPixelBox.Size = new System.Drawing.Size(106, 106);
            this.MedalPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MedalPixelBox.TabIndex = 16;
            this.MedalPixelBox.TabStop = false;
            // 
            // BestScoreLabel
            // 
            this.BestScoreLabel.Font = new System.Drawing.Font("Lucida Console", 36F);
            this.BestScoreLabel.ForeColor = System.Drawing.Color.White;
            this.BestScoreLabel.Location = new System.Drawing.Point(244, 195);
            this.BestScoreLabel.Name = "BestScoreLabel";
            this.BestScoreLabel.Size = new System.Drawing.Size(228, 54);
            this.BestScoreLabel.TabIndex = 15;
            this.BestScoreLabel.Text = "0";
            this.BestScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CurrScoreLabel
            // 
            this.CurrScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrScoreLabel.Font = new System.Drawing.Font("Lucida Console", 36F);
            this.CurrScoreLabel.ForeColor = System.Drawing.Color.White;
            this.CurrScoreLabel.Location = new System.Drawing.Point(244, 85);
            this.CurrScoreLabel.Name = "CurrScoreLabel";
            this.CurrScoreLabel.Size = new System.Drawing.Size(228, 54);
            this.CurrScoreLabel.TabIndex = 14;
            this.CurrScoreLabel.Text = "0";
            this.CurrScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScoreBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(506, 285);
            this.Controls.Add(this.NewPixelBox);
            this.Controls.Add(this.MedalPixelBox);
            this.Controls.Add(this.BestScoreLabel);
            this.Controls.Add(this.CurrScoreLabel);
            this.Controls.Add(this.ScoreBoardPixelBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScoreBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScoreBoardForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBoardPixelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPixelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedalPixelBox)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private CustomControls.PixelBox ScoreBoardPixelBox;
    private CustomControls.PixelBox NewPixelBox;
    private CustomControls.PixelBox MedalPixelBox;
    private Label BestScoreLabel;
    private Label CurrScoreLabel;
}