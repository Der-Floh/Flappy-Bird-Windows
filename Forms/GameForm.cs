using Flappy_Bird_Windows.Helper;
using Flappy_Bird_Windows.Repository.Bird;
using Flappy_Bird_Windows.Repository.Pipe;
using Flappy_Bird_Windows.Service.BirdManager;
using Flappy_Bird_Windows.Service.PipeManager;
using Microsoft.Extensions.DependencyInjection;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class GameForm : Form
{
    public GameOverForm GameOverForm { get; set; }
    public ScoreForm ScoreForm { get; set; }
    public bool IsGameOver { get; set; }
    public int BestScore { get; set; }

    private readonly IPipeManagerService _pipeManagerService;
    private readonly IPipeRepository _pipeRepository;
    private readonly IBirdManagerService _birdManagerService;
    private readonly IBirdRepository _birdRepository;

    private DateTime _lastScoreCount = DateTime.MinValue;

    public GameForm()
    {
        InitializeComponent();

        PipeSpawnTimer.Interval = Program.GameplayConfig.PipeSpawnDelay;

        GameOverForm = new GameOverForm();
        GameOverForm.FormClosed += (_, _) => Close();
        GameOverForm.RestartEvent += (_, _) => Reset();

        _pipeRepository = Program.Services!.GetRequiredService<IPipeRepository>();
        _birdRepository = Program.Services!.GetRequiredService<IBirdRepository>();
        _pipeManagerService = Program.Services!.GetRequiredService<IPipeManagerService>();
        _birdManagerService = Program.Services!.GetRequiredService<IBirdManagerService>();
        _birdManagerService.GameOver += (_, _) => GameOver();

        ScoreForm = new ScoreForm();
        ScoreForm.Show();

        Task.Run(CollisionChecker);

        Thread.Sleep(200);
        _birdManagerService.NewBird(Color.Yellow);
    }

    public void Reset()
    {
        GameOverForm.Hide();
        _pipeRepository.KillAll();

        ScoreForm.Close();
        ScoreForm = new ScoreForm();
        ScoreForm.Show();

        Thread.Sleep(200);

        PipeSpawnTimer.Enabled = true;
        PipeMoveTimer.Enabled = true;
        BirdMoveTimer.Enabled = true;
        _birdManagerService.ControlsEnabled = true;

        _birdManagerService.NewBird(Color.Yellow);
        IsGameOver = false;
    }

    private void GameOver()
    {
        IsGameOver = true;
        _birdRepository.KillAll();

        BirdMoveTimer.Enabled = false;
        PipeSpawnTimer.Enabled = false;
        PipeMoveTimer.Enabled = false;
        _birdManagerService.ControlsEnabled = false;

        if (Program.GameplayConfig.CloseOnLoose)
            Close();
        else if (Program.GameplayConfig.InstantRestart)
            Reset();
        else
            GameOverForm.ShowGameOver(ScoreForm.ScoreValue, BestScore);

        if (ScoreForm.ScoreValue > BestScore)
            BestScore = ScoreForm.ScoreValue;
    }

    public void CheckCollision()
    {
        try
        {
            foreach (var bird in _birdRepository.Birds)
            {
                var birdRect = new Rectangle(bird.Value.Location.X, bird.Value.Location.Y, bird.Value.Width, bird.Value.Height);
                if (_pipeManagerService.HasCollision(birdRect))
                {
                    BirdCollided(bird.Value);
                }
                if (_pipeManagerService.HasScoreCollision(birdRect) && _lastScoreCount.AddSeconds(1) < DateTime.Now)
                {
                    ScoreCollided(ScoreForm);
                    _lastScoreCount = DateTime.Now;
                }
            }
        }
        catch { }
    }

    private static void BirdCollided(BirdForm bird)
    {
        if (bird.InvokeRequired)
        {
            bird.BeginInvoke(new Action(() => BirdCollided(bird)));
            return;
        }
        bird.KillBird();
    }

    private static void ScoreCollided(ScoreForm score)
    {
        if (score.InvokeRequired)
        {
            score.BeginInvoke(new Action(() => ScoreCollided(score)));
            return;
        }
        score.AddScore();
    }

    private async Task CollisionChecker()
    {
        while (true)
        {
            if (IsGameOver)
                continue;

            CheckCollision();
            await Task.Delay(20);
        }
    }

    private void BirdMoveTimer_Tick(object sender, EventArgs e)
    {
        _birdManagerService.MoveBirds();

        if (!IsGameOver)
        {
            _birdManagerService.CheckKeyPresses();
            if (Keyboard.IsKeyDown(Program.ControlsConfig.GameOver))
                _birdRepository.KillAll();
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player1) && !_birdRepository.Birds.ContainsKey(Color.Yellow))
                _birdManagerService.NewBird(Color.Yellow);
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player2) && !_birdRepository.Birds.ContainsKey(Color.Blue))
                _birdManagerService.NewBird(Color.Blue);
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player3) && !_birdRepository.Birds.ContainsKey(Color.Red))
                _birdManagerService.NewBird(Color.Red);
        }
    }

    private void PipeSpawnTimer_Tick(object sender, EventArgs e) => _pipeManagerService.NewPipePair();

    private void PipeMoveTimer_Tick(object sender, EventArgs e) => _pipeManagerService.MovePipes();
}
