namespace Flappy_Bird_Windows.Data.Config;

public sealed class ControlsConfig
{
    public Keys Player1 { get; private set; } = Keys.Space;
    public Keys Player2 { get; private set; } = Keys.Up;
    public Keys Player3 { get; private set; } = Keys.NumPad8;
    public Keys GameOver { get; private set; } = Keys.Escape;

    public string Player1Key { get => _player1Key; set { _player1Key = value; Player1 = (Keys)Enum.Parse(typeof(Keys), value, true); } }
    private string _player1Key = "Space";
    public string Player2Key { get => _player2Key; set { _player2Key = value; Player2 = (Keys)Enum.Parse(typeof(Keys), value, true); } }
    private string _player2Key = "Up";
    public string Player3Key { get => _player3Key; set { _player3Key = value; Player3 = (Keys)Enum.Parse(typeof(Keys), value, true); } }
    private string _player3Key = "NumPad8";
    public string GameOverKey { get => _gameOverKey; set { _gameOverKey = value; GameOver = (Keys)Enum.Parse(typeof(Keys), value, true); } }
    private string _gameOverKey = "Escape";
}
