using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Data.Config;
using Flappy_Bird_Windows.Forms;
using Flappy_Bird_Windows.Repository.Bird;
using Flappy_Bird_Windows.Repository.Pipe;
using Flappy_Bird_Windows.Service.BirdManager;
using Flappy_Bird_Windows.Service.PipeManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Drawing.Text;

namespace Flappy_Bird_Windows;

internal static class Program
{
    public static ServiceProvider? Services { get; private set; }
    public static PrivateFontCollection Fonts { get; private set; } = new();
    public static ControlsConfig ControlsConfig { get; private set; } = new();
    public static GameplayConfig GameplayConfig { get; private set; } = new();
    public static ProgramConfig ProgramConfig { get; private set; } = new();

    [STAThread]
    static void Main()
    {
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

        RegisterServices();

        Fonts.AddFontFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "font.ttf"));

        IConfiguration? config = null;

        try
        {
            config = new ConfigurationBuilder().AddIniFile("config.ini").Build();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not find config file.{Environment.NewLine}{Environment.NewLine}{ex.Message}", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (config is not null)
        {
            TryLoadConfigSection(config, "controls", ControlsConfig);
            TryLoadConfigSection(config, "gameplay", GameplayConfig);
            TryLoadConfigSection(config, "program", ProgramConfig);
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new GameForm());
    }

    public static void RegisterServices()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IBirdRepository, BirdRepository>();
        serviceCollection.AddSingleton<IPipeRepository, PipeRepository>();
        serviceCollection.AddSingleton<IBirdManagerService, BirdManagerService>();
        serviceCollection.AddSingleton<IPipeManagerService, PipeManagerService>();
        serviceCollection.AddTransient<IPipePair, PipePair>();
        Services = serviceCollection.BuildServiceProvider();
    }

    private static bool TryLoadConfigSection(IConfiguration config, string sectionName, object bindObject)
    {
        try
        {
            config.GetSection(sectionName).Bind(bindObject);
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not load config section '{sectionName}'. Using default config instead.{Environment.NewLine}{Environment.NewLine}{ex.Message}", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}