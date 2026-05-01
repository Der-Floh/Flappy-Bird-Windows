using System.Diagnostics;

using Flappy_Bird_Windows.Data.Config;
using Flappy_Bird_Windows.Repository.Bird;
using Flappy_Bird_Windows.Repository.Pipe;
using Flappy_Bird_Windows.Service.BirdManager;
using Flappy_Bird_Windows.Service.GameState;
using Flappy_Bird_Windows.Service.Performance;
using Flappy_Bird_Windows.Service.PipeManager;
using Flappy_Bird_Windows.Service.ScoreManager;
using Flappy_Bird_Windows.Utility;

using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class GameForm : Form
{
    public GameOverForm GameOverForm { get; set; }
    public ScoreBoardForm ScoreBoardForm { get; set; }
    public SingleButtonForm RestartButtonForm { get; set; }
    public SingleButtonForm CloseButtonForm { get; set; }
    public ScoreForm ScoreForm { get; set; }
    public TapToStartForm TapToStartForm { get; set; }

    public bool IsGameOver => _gameStateService.CurrentState == GameState.GameOver;
    public bool Paused => _gameStateService.CurrentState == GameState.Paused;
    public bool IsBirdPreviewMode
    {
        get => _gameStateService.CurrentState == GameState.TapToStart;
        set => BirdMovePreviewTimer.Enabled = value;
    }

    public int ScoreValue { get; set { field = value; ScoreForm.ScoreValue = value; } }

    private readonly IPipeManagerService _pipeManagerService;
    private readonly IPipeRepository _pipeRepository;
    private readonly IBirdManagerService _birdManagerService;
    private readonly IBirdRepository _birdRepository;
    private readonly IGameStateService _gameStateService;
    private readonly IScoreService _scoreService;
    private readonly GameplayConfig _gameplayConfig;
    private readonly ControlsConfig _controlsConfig;
    private readonly ProgramConfig _programConfig;
    private readonly IFormFactory _formFactory;
    private readonly int _screenWidth;
    private readonly int _screenHeight;
    private readonly int _birdPreviewYTop;
    private readonly int _birdPreviewYBottom;
    private readonly int _birdSpawnHeight;
    private int _birdPreviewDirectionValue = 1;
    private readonly CancellationTokenSource _cts = new();
    private readonly IPerformanceService _performanceService;
    private DebugOverlayForm _debugOverlayForm = null!;

    public GameForm(IPipeManagerService pipeManagerService, IPipeRepository pipeRepository, IBirdManagerService birdManagerService, IBirdRepository birdRepository, IGameStateService gameStateService, IScoreService scoreService, IOptions<GameplayConfig> gameplayOptions, IOptions<ControlsConfig> controlsOptions, IOptions<ProgramConfig> programOptions, IFormFactory formFactory, IPerformanceService performanceService)
    {
        _pipeManagerService = pipeManagerService;
        _pipeRepository = pipeRepository;
        _birdManagerService = birdManagerService;
        _birdRepository = birdRepository;
        _gameStateService = gameStateService;
        _scoreService = scoreService;
        _gameplayConfig = gameplayOptions.Value;
        _controlsConfig = controlsOptions.Value;
        _programConfig = programOptions.Value;
        _formFactory = formFactory;
        _performanceService = performanceService;

        _screenWidth = Screen.PrimaryScreen!.Bounds.Width;
        _screenHeight = Screen.PrimaryScreen!.Bounds.Height;

        _birdPreviewYTop = (_screenHeight / 2) - (125 / 2);
        _birdPreviewYBottom = (_screenHeight / 2) - (125 / 3);
        _birdSpawnHeight = _gameplayConfig.TapToStart ? _birdPreviewYTop : 0;

        InitializeComponent();

        PipeSpawnTimer.Interval = _gameplayConfig.PipeSpawnDelay;

        GameOverForm = _formFactory.Create<GameOverForm>();
        ScoreBoardForm = _formFactory.Create<ScoreBoardForm>();

        if (_programConfig.SaveScore)
            _scoreService.LoadBestScore();

        RestartButtonForm = _formFactory.Create<SingleButtonForm>();
        RestartButtonForm.ButtonPixelBox.Image = Properties.Resources.ResourceManager.GetObject("button_restart") as Bitmap;
        RestartButtonForm.ButtonPixelBox.Click += (_, _) => Reset();
        RestartButtonForm.FormClosed += (_, _) => Close();

        CloseButtonForm = _formFactory.Create<SingleButtonForm>();
        CloseButtonForm.ButtonPixelBox.Image = Properties.Resources.ResourceManager.GetObject("button_close") as Bitmap;
        CloseButtonForm.ButtonPixelBox.Click += (_, _) => Close();
        CloseButtonForm.FormClosed += (_, _) => Close();

        _birdManagerService.GameOver += (_, _) => GameOver();

        ScoreForm = _formFactory.Create<ScoreForm>();
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        ScoreForm.Show();

        TapToStartForm = _formFactory.Create<TapToStartForm>();
        TapToStartForm.CloseMenuItem.Click += (_, _) => Close();
        TapToStartForm.OptionsMenuItem.Click += OptionsMenuItem_Click;

        _debugOverlayForm = _formFactory.Create<DebugOverlayForm>();

        Task.Run(() => GlobalKeyChecker(_cts.Token));

        Reset();
    }

    public void Start()
    {
        _gameStateService.Transition(GameState.Running);
        TapToStartForm.Hide();
        if (_birdRepository.Birds.Count == 0)
            _birdManagerService.NewBird(Color.Yellow, new Point(200, _birdSpawnHeight));
        BirdMovePreviewTimer.Enabled = false;
        PipeSpawnTimer.Enabled = true;
        PipeMoveTimer.Enabled = true;
        BirdMoveTimer.Enabled = true;
        CollisionTimer.Enabled = true;
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

        if (_gameStateService.CurrentState != GameState.Idle)
            _gameStateService.Transition(GameState.Idle);

        ScoreValue = 0;
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        ScoreForm.Show();

        _birdManagerService.NewBird(Color.Yellow, new Point(200, _birdSpawnHeight));

        if (_gameplayConfig.TapToStart)
        {
            BirdMoveTimer.Enabled = true;
            _birdManagerService.ControlsEnabled = true;
            BirdMovePreviewTimer.Enabled = true;
            _gameStateService.Transition(GameState.TapToStart);
            TapToStartForm.Location = new Point(375, _birdPreviewYBottom + 30);
            TapToStartForm.Show();
        }
        else
        {
            Start();
        }
    }

    public void Pause()
    {
        _gameStateService.Transition(GameState.Paused);
        BirdMoveTimer.Enabled = false;
        PipeMoveTimer.Enabled = false;
        PipeSpawnTimer.Enabled = false;
        BirdMovePreviewTimer.Enabled = false;
        CollisionTimer.Enabled = false;
        _birdManagerService.ControlsEnabled = false;
    }

    public void Resume()
    {
        _gameStateService.Transition(GameState.Running);
        BirdMoveTimer.Enabled = true;
        PipeMoveTimer.Enabled = true;
        PipeSpawnTimer.Enabled = true;
        BirdMovePreviewTimer.Enabled = false;
        CollisionTimer.Enabled = true;
        _birdManagerService.ControlsEnabled = true;
    }

    public void GameOver()
    {
        _gameStateService.Transition(GameState.GameOver);
        _birdRepository.KillAll();

        BirdMoveTimer.Enabled = false;
        PipeSpawnTimer.Enabled = false;
        PipeMoveTimer.Enabled = false;
        CollisionTimer.Enabled = false;
        _birdManagerService.ControlsEnabled = false;

        ScoreBoardForm.ScoreValue = ScoreValue;
        var isNewBest = _scoreService.RecordScore(ScoreValue);
        ScoreBoardForm.BestScoreValue = _scoreService.BestScore;
        if (isNewBest)
            ScoreBoardForm.ShowNewBest();

        if (_gameplayConfig.CloseOnLoose)
            Close();
        else if (_gameplayConfig.InstantRestart)
            Reset();
        else
            ShowGameOver();
    }

    private void ShowGameOver()
    {
        ScoreBoardForm.Location = new Point((_screenWidth / 2) - (ScoreBoardForm.Width / 2), (_screenHeight / 2) - (ScoreBoardForm.Height / 2));
        GameOverForm.Location = new Point((_screenWidth / 2) - (GameOverForm.Width / 2), ScoreBoardForm.Location.Y - GameOverForm.Height - 20);
        RestartButtonForm.Location = new Point((_screenWidth / 2) - RestartButtonForm.Width - 20, ScoreBoardForm.Location.Y + ScoreBoardForm.Height + 20);
        CloseButtonForm.Location = new Point((_screenWidth / 2) + 20, ScoreBoardForm.Location.Y + ScoreBoardForm.Height + 20);

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

    private void CheckCollision()
    {
        try
        {
            foreach (var bird in _birdRepository.Birds.ToArray())
            {
                var birdRect = new Rectangle(bird.Value.Location.X, bird.Value.Location.Y, bird.Value.Width, bird.Value.Height);
                if (_pipeManagerService.HasCollision(birdRect))
                    BirdCollided(bird.Value);
                if (_pipeManagerService.HasScoreCollision(birdRect))
                    ScoreValue += 1 * _gameplayConfig.ScoreMultiplier;
            }
        }
        catch (ObjectDisposedException) { /* bird form closed mid-check */ }
    }

    private async Task GlobalKeyChecker(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            if (Keyboard.IsKeyDown(_controlsConfig.GameOver))
            {
                Invoke(new Action(_birdRepository.KillAll));
                await Task.Delay(200, ct).ConfigureAwait(false);
            }
            if (Keyboard.IsKeyDown(_controlsConfig.Pause))
            {
                Invoke(new Action(() =>
                {
                    if (_gameStateService.CurrentState == GameState.Running)
                        Pause();
                    else if (_gameStateService.CurrentState == GameState.Paused)
                        Resume();
                }));
                await Task.Delay(200, ct).ConfigureAwait(false);
            }
            if (Keyboard.IsKeyDown(Keys.F3))
            {
                Invoke(new Action(() =>
                {
                    if (!_debugOverlayForm.Visible)
                    {
                        _debugOverlayForm.Location = new Point(10, 10);
                        _debugOverlayForm.Show();
                    }
                    else
                    {
                        _debugOverlayForm.Hide();
                    }
                }));
                await Task.Delay(200, ct).ConfigureAwait(false);
            }
            await Task.Delay(10, ct).ConfigureAwait(false);
        }
    }

    private void CheckControlKeys()
    {
        _birdManagerService.CheckKeyPresses();
        if (Keyboard.IsKeyDown(_controlsConfig.Player1) && !_birdRepository.Birds.ContainsKey(Color.Yellow))
            _birdManagerService.NewBird(Color.Yellow);
        if (Keyboard.IsKeyDown(_controlsConfig.Player2) && !_birdRepository.Birds.ContainsKey(Color.Blue))
            _birdManagerService.NewBird(Color.Blue);
        if (Keyboard.IsKeyDown(_controlsConfig.Player3) && !_birdRepository.Birds.ContainsKey(Color.Red))
            _birdManagerService.NewBird(Color.Red);
    }

    private static void BirdCollided(BirdForm bird)
    {
        bird.KillBird();
    }

    private void CollisionTimer_Tick(object sender, EventArgs e)
    {
        if (IsGameOver)
            return;
        var sw = Stopwatch.StartNew();
        CheckCollision();
        sw.Stop();
        _performanceService.RecordCollisionTime(sw.Elapsed);
    }

    private void OptionsMenuItem_Click(object? sender, EventArgs e)
    {
        var stateBeforeOptions = _gameStateService.CurrentState;

        BirdMoveTimer.Enabled = false;
        PipeMoveTimer.Enabled = false;
        PipeSpawnTimer.Enabled = false;
        BirdMovePreviewTimer.Enabled = false;
        CollisionTimer.Enabled = false;
        _birdManagerService.ControlsEnabled = false;

        if (stateBeforeOptions == GameState.Running)
            _gameStateService.Transition(GameState.Paused);

        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        var configForm = _formFactory.Create<ConfigForm>();
        configForm.FormClosed += (_, _) =>
        {
            PipeSpawnTimer.Interval = _gameplayConfig.PipeSpawnDelay;

            if (stateBeforeOptions == GameState.Running)
                Resume();
            else if (stateBeforeOptions == GameState.TapToStart)
            {
                BirdMoveTimer.Enabled = true;
                BirdMovePreviewTimer.Enabled = true;
                _birdManagerService.ControlsEnabled = true;
            }
        };
        configForm.ShowDialog();
    }

    private void BirdMoveTimer_Tick(object sender, EventArgs e)
    {
        if (IsBirdPreviewMode)
        {
            if (Keyboard.IsKeyDown(_controlsConfig.GameOver))
                _birdRepository.KillAll();
            if (Keyboard.IsKeyDown(_controlsConfig.Player1) || Keyboard.IsKeyDown(_controlsConfig.Player2) || Keyboard.IsKeyDown(_controlsConfig.Player3))
                Start();
            else
                return;
        }

        var sw = Stopwatch.StartNew();
        _birdManagerService.MoveBirds();
        sw.Stop();
        _performanceService.RecordPhysicsTime(sw.Elapsed);
        _performanceService.BirdCount = _birdRepository.Birds.Count;

        if (!IsGameOver)
            CheckControlKeys();
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

    private void PipeMoveTimer_Tick(object sender, EventArgs e)
    {
        _performanceService.RecordTick();
        _pipeManagerService.MovePipes();
    }

    private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _debugOverlayForm.Close();
        _cts.Cancel();
        _cts.Dispose();
    }
}
