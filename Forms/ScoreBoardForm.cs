using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Utility;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class ScoreBoardForm : Form
{
    public int Score { get => _score; set { _score = value; SetScore(value); } }
    private int _score;
    public int BestScore { get => _bestScore; set { _bestScore = value; BestScoreLabel.Text = value.ToString(); } }
    private int _bestScore;

    private readonly string _scoreSaveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Flappy Bird Windows");

    public ScoreBoardForm()
    {
        InitializeComponent();

        TopMost = Program.ProgramConfig.AlwaysOnTop;
        BackColor = Color.FromArgb(255, 222, 216, 149);

        CurrScoreLabel.Font = new Font(Program.Fonts.Families[0], CurrScoreLabel.Font.Size);
        BestScoreLabel.Font = new Font(Program.Fonts.Families[0], BestScoreLabel.Font.Size);
    }

    public void SetScore(int score)
    {
        if (Program.ProgramConfig.SaveScore && Score != 0)
            SaveScore();

        CurrScoreLabel.Text = score.ToString();
        if (score > BestScore)
        {
            BestScore = score;
            if (Program.ProgramConfig.SaveScore)
                SaveBestScore();
            NewPixelBox.Visible = true;
        }
        else
        {
            NewPixelBox.Visible = false;
        }
        SetScoreMedal(score);
    }

    public void SaveScore()
    {
        if (!Directory.Exists(_scoreSaveFolder))
            Directory.CreateDirectory(_scoreSaveFolder);

        var scoresCsv = string.Empty;
        if (File.Exists(Path.Combine(_scoreSaveFolder, "scores.csv")))
            scoresCsv = File.ReadAllText(Path.Combine(_scoreSaveFolder, "scores.csv"));

        var scores = CSVSerializer.Deserialize<Score>(scoresCsv).ToList();
        scores.Insert(0, new Score { Username = Environment.UserName, ScoreValue = Score, Time = DateTime.Now });
        if (scores.Count > Program.ProgramConfig.MaxSavedScores)
            scores.RemoveRange(Program.ProgramConfig.MaxSavedScores, scores.Count - Program.ProgramConfig.MaxSavedScores);
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
        scores.Insert(0, new Score { Username = Environment.UserName, ScoreValue = BestScore, Time = DateTime.Now });
        if (scores.Count > Program.ProgramConfig.MaxSavedScores)
            scores.RemoveRange(Program.ProgramConfig.MaxSavedScores, scores.Count - Program.ProgramConfig.MaxSavedScores);
        File.WriteAllText(Path.Combine(_scoreSaveFolder, "bestscores.csv"), CSVSerializer.Serialize(scores));
    }

    public void LoadBestScore()
    {
        if (!File.Exists(Path.Combine(_scoreSaveFolder, "bestscores.csv")))
            return;

        var scoresCsv = File.ReadAllText(Path.Combine(_scoreSaveFolder, "bestscores.csv"));
        var scores = CSVSerializer.Deserialize<Score>(scoresCsv);
        scores = scores.OrderByDescending(x => x.ScoreValue);
        BestScore = scores.FirstOrDefault()?.ScoreValue ?? 0;
    }

    public void SetScoreMedal(int score)
    {
        if (score >= 40)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_platinum") as Bitmap;
        else if (score >= 30)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_gold") as Bitmap;
        else if (score >= 20)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_silver") as Bitmap;
        else if (score >= 10)
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
