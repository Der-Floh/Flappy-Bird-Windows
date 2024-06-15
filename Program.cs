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

        IConfiguration config = new ConfigurationBuilder().AddIniFile("config.ini").Build();
        config.GetSection("controls").Bind(ControlsConfig);
        config.GetSection("gameplay").Bind(GameplayConfig);
        config.GetSection("program").Bind(ProgramConfig);

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
}