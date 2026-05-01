using Flappy_Bird_Windows.Data.Config;
using Flappy_Bird_Windows.Service.Performance;

using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class DebugOverlayForm : Form
{
    private readonly IPerformanceService _perf;

    public DebugOverlayForm(IPerformanceService perf, IOptions<ProgramConfig> programOptions)
    {
        _perf = perf;

        InitializeComponent();

        TopMost = programOptions.Value.AlwaysOnTop;
    }

    private void RefreshTimer_Tick(object sender, EventArgs e)
    {
        FpsLabel.Text = $"FPS:      {_perf.CurrentFps:F0}";
        CountsLabel.Text = $"Pipes: {_perf.PipeCount}   Birds: {_perf.BirdCount}";
        MoveLabel.Text = $"Move:  avg {_perf.AvgMoveMs:F2}ms  max {_perf.MaxMoveMs:F2}ms";
        PhysLabel.Text = $"Phys:  avg {_perf.AvgPhysicsMs:F2}ms  max {_perf.MaxPhysicsMs:F2}ms";
        CollLabel.Text = $"Coll:  avg {_perf.AvgCollisionMs:F2}ms  max {_perf.MaxCollisionMs:F2}ms";
    }
}
