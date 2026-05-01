using System.Diagnostics;

using Microsoft.Extensions.Logging;

namespace Flappy_Bird_Windows.Service.Performance;

public sealed class PerformanceService : IPerformanceService
{
    private const int SampleCapacity = 100;

    private readonly Queue<long> _tickTimestamps = new();
    private static readonly long TicksPerSecond = Stopwatch.Frequency;

    private readonly Queue<double> _moveSamples = new();
    private readonly Queue<double> _physicsSamples = new();
    private readonly Queue<double> _collisionSamples = new();

    private readonly ILogger<PerformanceService> _logger;
    private long _lastLogTimestamp = Stopwatch.GetTimestamp();
    private static readonly long LogIntervalTicks = Stopwatch.Frequency * 5;

    public int PipeCount { get; set; }
    public int BirdCount { get; set; }

    public PerformanceService(ILogger<PerformanceService> logger)
    {
        _logger = logger;
    }

    public void RecordTick()
    {
        var now = Stopwatch.GetTimestamp();

        _tickTimestamps.Enqueue(now);

        long cutoff = now - TicksPerSecond;
        while (_tickTimestamps.Count > 0 && _tickTimestamps.Peek() < cutoff)
            _tickTimestamps.Dequeue();

        if (now - _lastLogTimestamp >= LogIntervalTicks)
        {
            _lastLogTimestamp = now;
            _logger.LogDebug(
                "Perf — FPS={Fps:F1}  Move={MoveAvg:F2}ms  Phys={PhysAvg:F2}ms  Coll={CollAvg:F2}ms  Pipes={Pipes}  Birds={Birds}",
                CurrentFps, AvgMoveMs, AvgPhysicsMs, AvgCollisionMs, PipeCount, BirdCount);
        }
    }

    public void RecordMoveTime(TimeSpan elapsed)
    {
        if (_moveSamples.Count >= SampleCapacity)
            _moveSamples.Dequeue();
        _moveSamples.Enqueue(elapsed.TotalMilliseconds);
    }

    public void RecordPhysicsTime(TimeSpan elapsed)
    {
        if (_physicsSamples.Count >= SampleCapacity)
            _physicsSamples.Dequeue();
        _physicsSamples.Enqueue(elapsed.TotalMilliseconds);
    }

    public void RecordCollisionTime(TimeSpan elapsed)
    {
        if (_collisionSamples.Count >= SampleCapacity)
            _collisionSamples.Dequeue();
        _collisionSamples.Enqueue(elapsed.TotalMilliseconds);
    }

    public double CurrentFps => _tickTimestamps.Count;

    public double AvgMoveMs =>
        _moveSamples.Count == 0 ? 0.0 : _moveSamples.Sum() / _moveSamples.Count;

    public double MaxMoveMs =>
        _moveSamples.Count == 0 ? 0.0 : _moveSamples.Max();

    public double AvgPhysicsMs =>
        _physicsSamples.Count == 0 ? 0.0 : _physicsSamples.Sum() / _physicsSamples.Count;

    public double MaxPhysicsMs =>
        _physicsSamples.Count == 0 ? 0.0 : _physicsSamples.Max();

    public double AvgCollisionMs =>
        _collisionSamples.Count == 0 ? 0.0 : _collisionSamples.Sum() / _collisionSamples.Count;

    public double MaxCollisionMs =>
        _collisionSamples.Count == 0 ? 0.0 : _collisionSamples.Max();
}
