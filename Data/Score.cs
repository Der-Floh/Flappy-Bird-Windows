namespace Flappy_Bird_Windows.Data;

public sealed class Score
{
    public string? Username { get; set; }
    public int ScoreValue { get; set; }
    public DateTime Time { get; set; }
}
