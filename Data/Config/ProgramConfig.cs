namespace Flappy_Bird_Windows.Data.Config;

public sealed class ProgramConfig
{
    public bool AlwaysOnTop { get; set; } = true;
    public bool SaveScore { get; set; } = true;
    public int MaxSavedScores { get; set; } = 1000;
}
