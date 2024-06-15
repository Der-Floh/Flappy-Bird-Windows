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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreBoardForm));
        ScoreBoardPixelBox = new CustomControls.PixelBox();
        NewPixelBox = new CustomControls.PixelBox();
        MedalPixelBox = new CustomControls.PixelBox();
        BestScoreLabel = new Label();
        CurrScoreLabel = new Label();
        ((System.ComponentModel.ISupportInitialize)ScoreBoardPixelBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NewPixelBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)MedalPixelBox).BeginInit();
        SuspendLayout();
        // 
        // ScoreBoardPixelBox
        // 
        ScoreBoardPixelBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        ScoreBoardPixelBox.BackColor = Color.Transparent;
        ScoreBoardPixelBox.Image = Properties.Resources.score_board;
        ScoreBoardPixelBox.Location = new Point(0, 0);
        ScoreBoardPixelBox.Name = "ScoreBoardPixelBox";
        ScoreBoardPixelBox.Size = new Size(506, 288);
        ScoreBoardPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        ScoreBoardPixelBox.TabIndex = 12;
        ScoreBoardPixelBox.TabStop = false;
        // 
        // NewPixelBox
        // 
        NewPixelBox.BackColor = Color.Transparent;
        NewPixelBox.Image = Properties.Resources.text_new;
        NewPixelBox.Location = new Point(303, 146);
        NewPixelBox.Name = "NewPixelBox";
        NewPixelBox.Size = new Size(69, 35);
        NewPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        NewPixelBox.TabIndex = 17;
        NewPixelBox.TabStop = false;
        NewPixelBox.Visible = false;
        // 
        // MedalPixelBox
        // 
        MedalPixelBox.BackColor = Color.Transparent;
        MedalPixelBox.Image = Properties.Resources.medal_empty;
        MedalPixelBox.Location = new Point(55, 98);
        MedalPixelBox.Name = "MedalPixelBox";
        MedalPixelBox.Size = new Size(106, 106);
        MedalPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        MedalPixelBox.TabIndex = 16;
        MedalPixelBox.TabStop = false;
        // 
        // BestScoreLabel
        // 
        BestScoreLabel.Font = new Font("Lucida Console", 36F);
        BestScoreLabel.ForeColor = Color.White;
        BestScoreLabel.Location = new Point(244, 195);
        BestScoreLabel.Name = "BestScoreLabel";
        BestScoreLabel.Size = new Size(228, 54);
        BestScoreLabel.TabIndex = 15;
        BestScoreLabel.Text = "0";
        BestScoreLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // CurrScoreLabel
        // 
        CurrScoreLabel.BackColor = Color.Transparent;
        CurrScoreLabel.Font = new Font("Lucida Console", 36F);
        CurrScoreLabel.ForeColor = Color.White;
        CurrScoreLabel.Location = new Point(244, 85);
        CurrScoreLabel.Name = "CurrScoreLabel";
        CurrScoreLabel.Size = new Size(228, 54);
        CurrScoreLabel.TabIndex = 14;
        CurrScoreLabel.Text = "0";
        CurrScoreLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // ScoreBoardForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LemonChiffon;
        ClientSize = new Size(506, 285);
        Controls.Add(NewPixelBox);
        Controls.Add(MedalPixelBox);
        Controls.Add(BestScoreLabel);
        Controls.Add(CurrScoreLabel);
        Controls.Add(ScoreBoardPixelBox);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ScoreBoardForm";
        StartPosition = FormStartPosition.Manual;
        FormClosing += ScoreBoardForm_FormClosing;
        ((System.ComponentModel.ISupportInitialize)ScoreBoardPixelBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)NewPixelBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)MedalPixelBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private CustomControls.PixelBox ScoreBoardPixelBox;
    private CustomControls.PixelBox NewPixelBox;
    private CustomControls.PixelBox MedalPixelBox;
    private Label BestScoreLabel;
    private Label CurrScoreLabel;
}