namespace Flappy_Bird_Windows.Config;

public sealed class Gameplay
{
    public int BirdGravity { get; set; } = 1;
    public int BirdFlapPower { get; set; } = 30;
    public int BirdMaxFallSpeed { get; set; } = 30;
    public int PipeGapMin { get; set; } = 400;
    public int PipeGapMax { get; set; } = 500;
    public int PipeMoveSpeed { get; set; } = 5;
    public int PipeSpawnOffset { get; set; } = 0;
    public int PipeDespawnOffset { get; set; } = 0;
    public bool InstantRestart { get; set; } = false;
    public bool CloseOnLoose { get; set; } = false;
}
