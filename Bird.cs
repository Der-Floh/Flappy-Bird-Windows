namespace Flappy_Bird_Windows;

public partial class Bird : Form
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

    public Bird(Color color, Keys key)
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());

        _key = key;
        Color = color;
        var upFlapFileName = color.Name.ToLower() + "bird_upflap";
        var midFlapFileName = color.Name.ToLower() + "bird_midflap";
        var downFlapFileName = color.Name.ToLower() + "bird_downflap";
        var iconFileName = color.Name.ToLower() + "bird_icon";
        _upFlapImage = Properties.Resources.ResourceManager.GetObject(upFlapFileName) as Bitmap;
        _midFlapImage = Properties.Resources.ResourceManager.GetObject(midFlapFileName) as Bitmap;
        _downFlapImage = Properties.Resources.ResourceManager.GetObject(downFlapFileName) as Bitmap;

        InitializeComponent();

        Icon = Properties.Resources.ResourceManager.GetObject(iconFileName) as Icon;
        BackgroundImage = _upFlapImage;

        ControlsEnabled = true;
        Location = new Point(200, 0);
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
            Close();
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

    public void KillBird() => Close();

    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        switch (AnimationState)
        {
            case BirdAnimationState.UpFlap:
                BackgroundImage = _upFlapImage;
                break;
            case BirdAnimationState.MidFlap:
                BackgroundImage = _midFlapImage;
                break;
            case BirdAnimationState.DownFlap:
                BackgroundImage = _downFlapImage;
                break;
        }
        _animationStateIndex++;
        if (_animationStateIndex == Enum.GetNames<BirdAnimationState>().Length)
            _animationStateIndex = 0;
        AnimationState = (BirdAnimationState)_animationStateIndex;
    }

    private void Bird_Shown(object sender, EventArgs e) => AnimationTimer.Enabled = true;
}

public enum BirdAnimationState
{
    UpFlap,
    MidFlap,
    DownFlap
}
