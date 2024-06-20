using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Utility;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class ScoreBoardForm : Form
{
    public int ScoreValue { get => _scoreValue; set { _scoreValue = value; UpdateScore(); } }
    private int _scoreValue;
    public int BestScoreValue { get => _bestScoreValue; set { _bestScoreValue = value; BestScoreLabel.Text = value.ToString(); } }
    private int _bestScoreValue;

    private readonly string _scoreSaveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Flappy Bird Windows");

    public ScoreBoardForm()
    {
        InitializeComponent();

        ScoreBoardPixelBox.Location = new Point(0, 0);
        ScoreBoardPixelBox.Size = new Size(ClientSize.Width, ClientSize.Height);
        TopMost = Program.ProgramConfig.AlwaysOnTop;
        BackColor = Color.FromArgb(255, 222, 216, 149);

        CurrScoreLabel.Font = new Font(Program.Fonts.Families[0], CurrScoreLabel.Font.Size);
        BestScoreLabel.Font = new Font(Program.Fonts.Families[0], BestScoreLabel.Font.Size);
    }

    public void UpdateScore()
    {
        if (Program.ProgramConfig.SaveScore && ScoreValue != 0)
            SaveScore();

        CurrScoreLabel.Text = ScoreValue.ToString();
        if (ScoreValue > BestScoreValue)
        {
            BestScoreValue = ScoreValue;
            if (Program.ProgramConfig.SaveScore)
                SaveBestScore();
            NewPixelBox.Visible = true;
        }
        else
        {
            NewPixelBox.Visible = false;
        }
        UpdateScoreMedal();
    }

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

    public void SaveScore()
    {
        if (!Directory.Exists(_scoreSaveFolder))
            Directory.CreateDirectory(_scoreSaveFolder);

        var scoresCsv = string.Empty;
        if (File.Exists(Path.Combine(_scoreSaveFolder, "scores.csv")))
            scoresCsv = File.ReadAllText(Path.Combine(_scoreSaveFolder, "scores.csv"));

        var scores = CSVSerializer.Deserialize<Score>(scoresCsv).ToList();
        scores.Insert(0, new Score { Username = Environment.UserName, ScoreValue = ScoreValue, Time = DateTime.Now });
        if (scores.Count > Program.ProgramConfig.SavedScoresMax)
            scores.RemoveRange(Program.ProgramConfig.SavedScoresMax, scores.Count - Program.ProgramConfig.SavedScoresMax);
        File.WriteAllText(Path.Combine(_scoreSaveFolder, "scores.csv"), CSVSerializer.Serialize(scores));
    }

    public void SaveBestScore()
    {
        if (!Directory.Exists(_scoreSaveFolder))
            Directory.CreateDirectory(_scoreSaveFolder);

        var scoresCsv = string.Empty;
        if (File.Exists(Path.Combine(_scoreSaveFolder, "bestscores.csv")))
            scoresCsv = File.ReadAllText(Path.Combine(_scoreSaveFolder, "bestscores.csv"));

        var scores = CSVSerializer.Deserialize<Score>(scoresCsv).ToList();
        scores.Insert(0, new Score { Username = Environment.UserName, ScoreValue = BestScoreValue, Time = DateTime.Now });
        if (scores.Count > Program.ProgramConfig.SavedScoresMax)
            scores.RemoveRange(Program.ProgramConfig.SavedScoresMax, scores.Count - Program.ProgramConfig.SavedScoresMax);
        File.WriteAllText(Path.Combine(_scoreSaveFolder, "bestscores.csv"), CSVSerializer.Serialize(scores));
    }

    public void LoadBestScore()
    {
        if (!File.Exists(Path.Combine(_scoreSaveFolder, "bestscores.csv")))
            return;

        var scoresCsv = File.ReadAllText(Path.Combine(_scoreSaveFolder, "bestscores.csv"));
        var scores = CSVSerializer.Deserialize<Score>(scoresCsv);
        scores = scores.OrderByDescending(x => x.ScoreValue);
        BestScoreValue = scores.FirstOrDefault()?.ScoreValue ?? 0;
    }

    private void ScoreBoardForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
}
