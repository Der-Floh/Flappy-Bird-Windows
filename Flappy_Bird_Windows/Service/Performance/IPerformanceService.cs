namespace Flappy_Bird_Windows.Service.Performance;

public interface IPerformanceService
{
    void RecordTick();
    void RecordMoveTime(TimeSpan elapsed);
    void RecordPhysicsTime(TimeSpan elapsed);
    void RecordCollisionTime(TimeSpan elapsed);

    double CurrentFps { get; }
    double AvgMoveMs { get; }
    double MaxMoveMs { get; }
    double AvgPhysicsMs { get; }
    double MaxPhysicsMs { get; }
    double AvgCollisionMs { get; }
    double MaxCollisionMs { get; }

    int PipeCount { get; set; }
    int BirdCount { get; set; }
}
