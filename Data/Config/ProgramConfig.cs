namespace Flappy_Bird_Windows.Data.Config;

[ConfigSection("program")]
public sealed class ProgramConfig
{
    public bool AlwaysOnTop { get; set; } = true;
    public bool SaveScore { get; set; } = true;
    public int SavedScoresMax { get; set; } = 1000;
}
