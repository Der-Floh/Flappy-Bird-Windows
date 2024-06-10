namespace Flappy_Bird_Windows;

public partial class Bird : Form
{
    public bool ControlsEnabled { get; set; }
    public BirdAnimationState AnimationState { get; set; }
    public BirdPlayer Player { get; set; }
    public Color Color { get; set; }

    public int Velocity_Y { get; set; }

    private const int Gravity = 1;
    private const int FlapPower = -30;
    private const int MaxFallSpeed = 30;
    private const int upwardVelocityDecay = 2;

    private bool SpaceUp = true;
    private bool UpArrowUp = true;
    private bool Num8Up = true;

    public Bird(Color color)
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());

        InitializeComponent();

        Color = color;
        ControlsEnabled = true;
        Location = new Point(200, 0);
        Player = new BirdPlayer(color);
        BackgroundImage = Player.UpFlapImage;
        Icon = Player.Icon;
    }

    public void MoveBird()
    {
        if (Velocity_Y < 0)
            Velocity_Y += upwardVelocityDecay;
        else
            Velocity_Y += Gravity;

        if (Velocity_Y > MaxFallSpeed)
            Velocity_Y = MaxFallSpeed;

        Location = new Point(Location.X, Math.Max(Location.Y + Velocity_Y, 0));

        if (Location.Y > Screen.PrimaryScreen!.Bounds.Height)
            Close();
    }

    public void CheckKeyPress()
    {
        if ((Keyboard.IsKeyDown(Keys.Space) && Color == Color.Yellow && SpaceUp)
            || (Keyboard.IsKeyDown(Keys.Up) && Color == Color.Blue && UpArrowUp)
            || (Keyboard.IsKeyDown(Keys.NumPad8) && Color == Color.Red) && Num8Up)
        {
            FlapBird();
        }

        SpaceUp = Keyboard.IsKeyUp(Keys.Space);
        UpArrowUp = Keyboard.IsKeyUp(Keys.Up);
        Num8Up = Keyboard.IsKeyUp(Keys.NumPad8);
    }

    public void FlapBird()
    {
        if (ControlsEnabled)
            Velocity_Y = FlapPower;
    }

    public void KillBird() => Close();

    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        switch (AnimationState)
        {
            case BirdAnimationState.UpFlap:
                BackgroundImage = Player.UpFlapImage;
                AnimationState = BirdAnimationState.MidFlap;
                break;
            case BirdAnimationState.MidFlap:
                BackgroundImage = Player.MidFlapImage;
                AnimationState = BirdAnimationState.DownFlap;
                break;
            case BirdAnimationState.DownFlap:
                BackgroundImage = Player.DownFlapImage;
                AnimationState = BirdAnimationState.UpFlap;
                break;
        }
    }

    private void Bird_Shown(object sender, EventArgs e)
    {
        AnimationTimer.Enabled = true;
    }
}

public enum BirdAnimationState
{
    UpFlap,
    DownFlap,
    MidFlap
}
