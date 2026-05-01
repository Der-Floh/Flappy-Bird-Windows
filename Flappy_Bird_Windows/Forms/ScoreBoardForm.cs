using Flappy_Bird_Windows.Data.Config;

using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class ScoreBoardForm : Form
{
    public int ScoreValue
    {
        get;
        set
        {
            field = value;
            CurrScoreLabel.Text = value.ToString();
            UpdateScoreMedal();
        }
    }

    public int BestScoreValue { get; set { field = value; BestScoreLabel.Text = value.ToString(); } }

    public ScoreBoardForm(IOptions<ProgramConfig> programOptions)
    {
        InitializeComponent();

        ScoreBoardPixelBox.Location = new Point(0, 0);
        ScoreBoardPixelBox.Size = new Size(ClientSize.Width, ClientSize.Height);
        TopMost = programOptions.Value.AlwaysOnTop;
        BackColor = Color.FromArgb(255, 222, 216, 149);

        CurrScoreLabel.Font = new Font(Program.Fonts.Families[0], CurrScoreLabel.Font.Size);
        BestScoreLabel.Font = new Font(Program.Fonts.Families[0], BestScoreLabel.Font.Size);

        NewPixelBox.Visible = false;
    }

    public void ShowNewBest() => NewPixelBox.Visible = true;

    public void UpdateScoreMedal()
    {
        if (ScoreValue >= 40)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_platinum") as Bitmap;
        else if (ScoreValue >= 30)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_gold") as Bitmap;
        else if (ScoreValue >= 20)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_silver") as Bitmap;
        else if (ScoreValue >= 10)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_bronze") as Bitmap;
        else
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_empty") as Bitmap;
    }

    private void ScoreBoardForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
}
