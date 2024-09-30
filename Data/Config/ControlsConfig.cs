namespace Flappy_Bird_Windows.Data.Config;

[ConfigSection("controls")]
public sealed class ControlsConfig
{
    public Keys Player1 { get; set; } = Keys.Space;
    public Keys Player2 { get; set; } = Keys.Up;
    public Keys Player3 { get; set; } = Keys.NumPad8;
    public Keys GameOver { get; set; } = Keys.Escape;
    public Keys Pause { get; set; } = Keys.P;
}
