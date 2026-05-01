using Flappy_Bird_Windows.Data.Config;
using Flappy_Bird_Windows.Utility;

using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class BirdForm : Form
{
    public bool ControlsEnabled { get; set; }
    public BirdAnimationState AnimationState { get; set; }
    public Color Color { get; set; }

    public float Velocity_Y { get; set; }

    private readonly Bitmap? _upFlapImage;
    private readonly Bitmap? _midFlapImage;
    private readonly Bitmap? _downFlapImage;
    private readonly Keys _key = Keys.None;
    private readonly GameplayConfig _gameplayConfig;

    private bool _keyUp = true;
    private int _animationStateIndex;
    private int _animationStateDirection = 1;

    public BirdForm(Color color, IOptions<GameplayConfig> gameplayOptions, IOptions<ControlsConfig> controlsOptions, IOptions<ProgramConfig> programOptions)
    {
        _gameplayConfig = gameplayOptions.Value;
        var controlsConfig = controlsOptions.Value;
        var programConfig = programOptions.Value;

        _key = GetKeyFromColor(color, controlsConfig);
        Color = color;
        var upFlapFileName = color.Name.ToLower() + "bird_upflap";
        var midFlapFileName = color.Name.ToLower() + "bird_midflap";
        var downFlapFileName = color.Name.ToLower() + "bird_downflap";
        var iconFileName = color.Name.ToLower() + "bird_icon";
        _upFlapImage = Properties.Resources.ResourceManager.GetObject(upFlapFileName) as Bitmap;
        _midFlapImage = Properties.Resources.ResourceManager.GetObject(midFlapFileName) as Bitmap;
        _downFlapImage = Properties.Resources.ResourceManager.GetObject(downFlapFileName) as Bitmap;

        InitializeComponent();

        BirdPixelBox.Location = new Point(0, 0);
        BirdPixelBox.Size = new Size(ClientSize.Width, ClientSize.Height);
        TopMost = programConfig.AlwaysOnTop;

        Icon = Properties.Resources.ResourceManager.GetObject(iconFileName) as Icon;
        BirdPixelBox.Image = _upFlapImage;

        ControlsEnabled = true;
    }

    public void MoveBird()
    {
        if (Velocity_Y < 0)
            Velocity_Y += _gameplayConfig.BirdGravity * 1.8f;
        else
            Velocity_Y += _gameplayConfig.BirdGravity;

        if (Velocity_Y > _gameplayConfig.BirdMaxFallSpeed)
            Velocity_Y = _gameplayConfig.BirdMaxFallSpeed;

        Location = new Point(Location.X, (int)Math.Round(Math.Max(Location.Y + Velocity_Y, 0)));

        if (Location.Y > Screen.PrimaryScreen!.Bounds.Height)
            KillBird();
    }

    public void CheckKeyPress()
    {
        if (Keyboard.IsKeyDown(_key) && _keyUp)
            FlapBird();

        _keyUp = Keyboard.IsKeyUp(_key);
    }

    public void FlapBird()
    {
        if (ControlsEnabled)
            Velocity_Y = -(_gameplayConfig.BirdFlapPower * (_gameplayConfig.BirdGravity / (_gameplayConfig.BirdGravity * 1.8f / 2)));
    }

    public void DisposeImages()
    {
        BirdPixelBox.Image?.Dispose();
        _upFlapImage?.Dispose();
        _midFlapImage?.Dispose();
        _downFlapImage?.Dispose();
    }

    public void KillBird() => Close();

    private static Keys GetKeyFromColor(Color color, ControlsConfig controls)
    {
        if (color == Color.Yellow)
            return controls.Player1;
        if (color == Color.Blue)
            return controls.Player2;
        if (color == Color.Red)
            return controls.Player3;
        return Keys.None;
    }

    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        switch (AnimationState)
        {
            case BirdAnimationState.UpFlap:
                BirdPixelBox.Image = _upFlapImage;
                break;
            case BirdAnimationState.MidFlap:
                BirdPixelBox.Image = _midFlapImage;
                break;
            case BirdAnimationState.DownFlap:
                BirdPixelBox.Image = _downFlapImage;
                break;
        }
        _animationStateIndex += _animationStateDirection;
        if (_animationStateIndex == Enum.GetNames<BirdAnimationState>().Length || _animationStateIndex == -1)
        {
            _animationStateDirection = -_animationStateDirection;
            _animationStateIndex += _animationStateDirection;
        }
        AnimationState = (BirdAnimationState)_animationStateIndex;
    }

    private void Bird_Shown(object sender, EventArgs e)
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        AnimationTimer.Enabled = true;
    }
}

public enum BirdAnimationState
{
    UpFlap,
    MidFlap,
    DownFlap
}
