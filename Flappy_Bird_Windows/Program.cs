using System.Diagnostics;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Data.Config;
using Flappy_Bird_Windows.Forms;
using Flappy_Bird_Windows.Repository.Bird;
using Flappy_Bird_Windows.Repository.Pipe;
using Flappy_Bird_Windows.Repository.Scores;
using Flappy_Bird_Windows.Service.BirdManager;
using Flappy_Bird_Windows.Service.Config;
using Flappy_Bird_Windows.Service.GameState;
using Flappy_Bird_Windows.Service.Performance;
using Flappy_Bird_Windows.Service.PipeManager;
using Flappy_Bird_Windows.Service.ScoreManager;
using Flappy_Bird_Windows.Utility;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Flappy_Bird_Windows;

internal static class Program
{
    public static PrivateFontCollection Fonts { get; private set; } = new();

    [STAThread]
    static void Main()
    {
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

        var fontBytes = Properties.Resources.font;
        var fontHandle = GCHandle.Alloc(fontBytes, GCHandleType.Pinned);
        var fontPtr = fontHandle.AddrOfPinnedObject();
        Fonts.AddMemoryFont(fontPtr, fontBytes.Length);

        var services = BuildServiceProvider();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(true);
        Application.Run(services.GetRequiredService<GameForm>());
    }

    private static ServiceProvider BuildServiceProvider()
    {
        var config = BuildConfiguration();

        var sc = new ServiceCollection();

        sc.AddLogging(b => b.AddDebug().SetMinimumLevel(LogLevel.Debug));

        sc.AddOptions();
        sc.Configure(BindSection<GameplayConfig>(config));
        sc.Configure(BindSection<ControlsConfig>(config));
        sc.Configure(BindSection<ProgramConfig>(config));

        sc.AddSingleton<IConfigService, ConfigService>();
        sc.AddSingleton<IGameStateService, GameStateService>();
        sc.AddSingleton<IPerformanceService, PerformanceService>();

        sc.AddSingleton<IBirdRepository, BirdRepository>();
        sc.AddSingleton<IPipeRepository, PipeRepository>();
        sc.AddSingleton<IScoreRepository, ScoreRepository>();
        sc.AddTransient<IPipePair, PipePair>();

        sc.AddSingleton<IBirdManagerService, BirdManagerService>();
        sc.AddSingleton<IPipeManagerService, PipeManagerService>();
        sc.AddSingleton<IScoreService, ScoreService>();

        sc.AddSingleton<IFormFactory, FormFactory>();

        sc.AddTransient<GameForm>();

        return sc.BuildServiceProvider();
    }

    private static IConfiguration BuildConfiguration()
        => new ConfigurationBuilder().AddIniFile("config.ini", optional: true).Build();

    private static Action<T> BindSection<T>(IConfiguration config) where T : class
    {
        var attr = typeof(T).GetCustomAttribute<ConfigSectionAttribute>()
                   ?? throw new InvalidOperationException($"{typeof(T).Name} has no ConfigSectionAttribute");

        return opts =>
        {
            try
            {
                config.GetSection(attr.SectionName).Bind(opts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not load config section '{attr.SectionName}'. Using default config instead.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
    }
}
