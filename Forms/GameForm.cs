using Flappy_Bird_Windows.Repository.Bird;
using Flappy_Bird_Windows.Repository.Pipe;
using Flappy_Bird_Windows.Service.BirdManager;
using Flappy_Bird_Windows.Service.PipeManager;
using Flappy_Bird_Windows.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class GameForm : Form
{
    public GameOverForm GameOverForm { get; set; }
    public ScoreBoardForm ScoreBoardForm { get; set; }
    public SingleButtonForm RestartButtonForm { get; set; }
    public SingleButtonForm CloseButtonForm { get; set; }
    public ScoreForm ScoreForm { get; set; }
    public TapToStartForm TapToStartForm { get; set; }
    public bool IsGameOver { get; set; }
    public int ScoreValue { get => _scorerValue; set { _scorerValue = value; ScoreForm.ScoreValue = value; } }
    private int _scorerValue;
    public bool IsBirdPreviewMode { get => _isBirdPreviewMode; set { _isBirdPreviewMode = value; BirdMovePreviewTimer.Enabled = value; } }
    private bool _isBirdPreviewMode = true;

    private readonly IPipeManagerService _pipeManagerService;
    private readonly IPipeRepository _pipeRepository;
    private readonly IBirdManagerService _birdManagerService;
    private readonly IBirdRepository _birdRepository;
    private readonly int _screenWidth;
    private readonly int _screenHeight;
    private readonly int _birdPreviewYTop;
    private readonly int _birdPreviewYBottom;
    private readonly int _birdSpawnHeight;
    private int _birdPreviewDirectionValue = 1;

    public GameForm()
    {
        _screenWidth = Screen.PrimaryScreen!.Bounds.Width;
        _screenHeight = Screen.PrimaryScreen!.Bounds.Height;

        _birdPreviewYTop = (int)(_screenHeight / 3.3 + 125);
        _birdPreviewYBottom = _screenHeight / 2 - 125;

        _birdSpawnHeight = Program.GameplayConfig.TapToStart ? _birdPreviewYTop : 0;

        InitializeComponent();

        PipeSpawnTimer.Interval = Program.GameplayConfig.PipeSpawnDelay;

        GameOverForm = new GameOverForm();
        ScoreBoardForm = new ScoreBoardForm();
        if (Program.ProgramConfig.SaveScore)
            ScoreBoardForm.LoadBestScore();

        RestartButtonForm = new SingleButtonForm();
        RestartButtonForm.ButtonPixelBox.Image = Properties.Resources.ResourceManager.GetObject("button_restart") as Bitmap;
        RestartButtonForm.ButtonPixelBox.Click += (_, _) => Reset();
        RestartButtonForm.FormClosed += (_, _) => Close();

        CloseButtonForm = new SingleButtonForm();
        CloseButtonForm.ButtonPixelBox.Image = Properties.Resources.ResourceManager.GetObject("button_close") as Bitmap;
        CloseButtonForm.ButtonPixelBox.Click += (_, _) => Close();
        CloseButtonForm.FormClosed += (_, _) => Close();

        _pipeRepository = Program.Services!.GetRequiredService<IPipeRepository>();
        _birdRepository = Program.Services!.GetRequiredService<IBirdRepository>();
        _pipeManagerService = Program.Services!.GetRequiredService<IPipeManagerService>();
        _birdManagerService = Program.Services!.GetRequiredService<IBirdManagerService>();
        _birdManagerService.GameOver += (_, _) => GameOver();

        ScoreForm = new ScoreForm();
        ScoreForm.Show();

        TapToStartForm = new TapToStartForm();

        Task.Run(CollisionChecker);

        Reset();
    }

    public void Start()
    {
        IsGameOver = false;
        TapToStartForm.Hide();
        if (_birdRepository.Birds.Count == 0)
            _birdManagerService.NewBird(Color.Yellow, new Point(200, _birdSpawnHeight));
        IsBirdPreviewMode = false;
        PipeSpawnTimer.Enabled = true;
        PipeMoveTimer.Enabled = true;
        BirdMoveTimer.Enabled = true;
        _birdManagerService.ControlsEnabled = true;
        _pipeManagerService.NewPipePair();
    }

    public void Reset()
    {
        GameOverForm.Hide();
        ScoreBoardForm.Hide();
        RestartButtonForm.Hide();
        CloseButtonForm.Hide();
        _pipeRepository.KillAll();

        ScoreValue = 0;
        ScoreForm.Show();

        IsGameOver = false;
        _birdManagerService.NewBird(Color.Yellow, new Point(200, _birdSpawnHeight));

        if (Program.GameplayConfig.TapToStart)
        {
            BirdMoveTimer.Enabled = true;
            _birdManagerService.ControlsEnabled = true;
            IsBirdPreviewMode = true;
            TapToStartForm.Location = new Point(375, _birdPreviewYBottom + 30);
            TapToStartForm.Show();
        }
        else
        {
            Start();
        }
    }

    public void GameOver()
    {
        IsGameOver = true;
        _birdRepository.KillAll();

        BirdMoveTimer.Enabled = false;
        PipeSpawnTimer.Enabled = false;
        PipeMoveTimer.Enabled = false;
        _birdManagerService.ControlsEnabled = false;

        ScoreBoardForm.ScoreValue = ScoreValue;

        if (Program.GameplayConfig.CloseOnLoose)
            Close();
        else if (Program.GameplayConfig.InstantRestart)
            Reset();
        else
            ShowGameOver();
    }

    public void ShowGameOver()
    {
        ScoreBoardForm.Location = new Point(_screenWidth / 2 - ScoreBoardForm.Width / 2, _screenHeight / 2 - ScoreBoardForm.Height / 2);
        GameOverForm.Location = new Point(_screenWidth / 2 - GameOverForm.Width / 2, ScoreBoardForm.Location.Y - GameOverForm.Height - 20);
        RestartButtonForm.Location = new Point(_screenWidth / 2 - RestartButtonForm.Width - 20, ScoreBoardForm.Location.Y + ScoreBoardForm.Height + 20);
        CloseButtonForm.Location = new Point(_screenWidth / 2 + 20, ScoreBoardForm.Location.Y + ScoreBoardForm.Height + 20);

        ScoreForm.Hide();
        TapToStartForm.Hide();

        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        GameOverForm.Show();
        ScoreBoardForm.Show();
        Thread.Sleep(100);
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        RestartButtonForm.Show();
        CloseButtonForm.Show();
    }

    public void CheckCollision()
    {
        try
        {
            foreach (var bird in _birdRepository.Birds)
            {
                var birdRect = new Rectangle(bird.Value.Location.X, bird.Value.Location.Y, bird.Value.Width, bird.Value.Height);
                if (_pipeManagerService.HasCollision(birdRect))
                    BirdCollided(bird.Value);
                if (_pipeManagerService.HasScoreCollision(birdRect))
                    ScoreValue += 1 * Program.GameplayConfig.ScoreMultiplier;
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
        if (IsBirdPreviewMode)
        {
            if (Keyboard.IsKeyDown(Program.ControlsConfig.GameOver))
                _birdRepository.KillAll();
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player1) || Keyboard.IsKeyDown(Program.ControlsConfig.Player2) || Keyboard.IsKeyDown(Program.ControlsConfig.Player3))
                Start();
            else
                return;
        }

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

    private void BirdMovePreviewTimer_Tick(object sender, EventArgs e)
    {
        if (_birdRepository.Birds.Count == 0)
            return;
        var bird = _birdRepository.Birds[Color.Yellow];
        bird.Location = new Point(bird.Location.X, bird.Location.Y + _birdPreviewDirectionValue);
        if (_birdPreviewDirectionValue > 0 && bird.Location.Y >= _birdPreviewYBottom)
            _birdPreviewDirectionValue = -_birdPreviewDirectionValue;
        else if (_birdPreviewDirectionValue < 0 && bird.Location.Y <= _birdPreviewYTop)
            _birdPreviewDirectionValue = -_birdPreviewDirectionValue;

    }

    private void PipeSpawnTimer_Tick(object sender, EventArgs e)
    {
        _pipeManagerService.NewPipePair();
        ScoreForm.Focus();
    }

    private void PipeMoveTimer_Tick(object sender, EventArgs e) => _pipeManagerService.MovePipes();
}
