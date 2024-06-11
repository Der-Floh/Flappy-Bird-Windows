namespace Flappy_Bird_Windows;

public partial class Bird : Form
{
    public bool ControlsEnabled { get; set; }
    public BirdAnimationState AnimationState { get; set; }
    public BirdPlayer Player { get; set; }
    public Color Color { get; set; }

    public int Velocity_Y { get; set; }

    private const int upwardVelocityDecay = 2;

    private bool Player1Up = true;
    private bool Player2Up = true;
    private bool Player3Up = true;

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
            Velocity_Y += Program.GamePlayConfig.BirdGravity;

        if (Velocity_Y > Program.GamePlayConfig.BirdMaxFallSpeed)
            Velocity_Y = Program.GamePlayConfig.BirdMaxFallSpeed;

        Location = new Point(Location.X, Math.Max(Location.Y + Velocity_Y, 0));

        if (Location.Y > Screen.PrimaryScreen!.Bounds.Height)
            Close();
    }

    public void CheckKeyPress()
    {
        if ((Keyboard.IsKeyDown(Program.ControlsConfig.Player1) && Color == Color.Yellow && Player1Up)
            || (Keyboard.IsKeyDown(Program.ControlsConfig.Player2) && Color == Color.Blue && Player2Up)
            || (Keyboard.IsKeyDown(Program.ControlsConfig.Player3) && Color == Color.Red) && Player3Up)
        {
            FlapBird();
        }

        Player1Up = Keyboard.IsKeyUp(Program.ControlsConfig.Player1);
        Player2Up = Keyboard.IsKeyUp(Program.ControlsConfig.Player2);
        Player3Up = Keyboard.IsKeyUp(Program.ControlsConfig.Player3);
    }

    public void FlapBird()
    {
        if (ControlsEnabled)
            Velocity_Y = -Program.GamePlayConfig.BirdFlapPower;
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
