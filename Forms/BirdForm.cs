using Flappy_Bird_Windows.Utility;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class BirdForm : Form
{
    public bool ControlsEnabled { get; set; }
    public BirdAnimationState AnimationState { get; set; }
    public Color Color { get; set; }

    public int Velocity_Y { get; set; }
    public int UpwardVelocityDecay { get; set; } = 2;

    private readonly Bitmap? _upFlapImage;
    private readonly Bitmap? _midFlapImage;
    private readonly Bitmap? _downFlapImage;
    private readonly Keys _key = Keys.None;

    private bool _keyUp = true;
    private int _animationStateIndex;
    private int _animationStateDirection = 1;

    public BirdForm(Color color)
    {
        _key = GetKeyFromColor(color);
        Color = color;
        var upFlapFileName = color.Name.ToLower() + "bird_upflap";
        var midFlapFileName = color.Name.ToLower() + "bird_midflap";
        var downFlapFileName = color.Name.ToLower() + "bird_downflap";
        var iconFileName = color.Name.ToLower() + "bird_icon";
        _upFlapImage = Properties.Resources.ResourceManager.GetObject(upFlapFileName) as Bitmap;
        _midFlapImage = Properties.Resources.ResourceManager.GetObject(midFlapFileName) as Bitmap;
        _downFlapImage = Properties.Resources.ResourceManager.GetObject(downFlapFileName) as Bitmap;

        InitializeComponent();

        TopMost = Program.ProgramConfig.AlwaysOnTop;

        Icon = Properties.Resources.ResourceManager.GetObject(iconFileName) as Icon;
        BirdPixelBox.Image = _upFlapImage;

        ControlsEnabled = true;
    }

    public void MoveBird()
    {
        if (Velocity_Y < 0)
            Velocity_Y += UpwardVelocityDecay;
        else
            Velocity_Y += Program.GameplayConfig.BirdGravity;

        if (Velocity_Y > Program.GameplayConfig.BirdMaxFallSpeed)
            Velocity_Y = Program.GameplayConfig.BirdMaxFallSpeed;

        Location = new Point(Location.X, Math.Max(Location.Y + Velocity_Y, 0));

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
            Velocity_Y = -Program.GameplayConfig.BirdFlapPower;
    }

    public void DisposeImages()
    {
        BirdPixelBox.Image?.Dispose();
        _upFlapImage?.Dispose();
        _midFlapImage?.Dispose();
        _downFlapImage?.Dispose();
    }

    public void KillBird() => Close();

    private static Keys GetKeyFromColor(Color color)
    {
        if (color == Color.Yellow)
            return Program.ControlsConfig.Player1;
        else if (color == Color.Blue)
            return Program.ControlsConfig.Player2;
        else if (color == Color.Red)
            return Program.ControlsConfig.Player3;
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
