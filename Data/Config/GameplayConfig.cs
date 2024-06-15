namespace Flappy_Bird_Windows.Data.Config;

public sealed class GameplayConfig
{
    public int BirdGravity { get; set; } = 1;
    public int BirdFlapPower { get; set; } = 30;
    public int BirdMaxFallSpeed { get; set; } = 30;
    public int PipeScreenDistanceMin { get; set; } = 100;
    public int PipeGapMin { get; set; } = 450;
    public int PipeGapMax { get; set; } = 600;
    public int PipeGapShiftMin { get; set; } = 100;
    public int PipeGapShiftMax { get; set; } = 300;
    public int PipeMoveSpeed { get; set; } = 5;
    public int PipeSpawnOffset { get; set; } = 0;
    public int PipeDespawnOffset { get; set; } = 0;
    public int PipeSpawnDelay { get; set; } = 3000;
    public bool InstantRestart { get; set; } = false;
    public bool CloseOnLoose { get; set; } = false;
}
