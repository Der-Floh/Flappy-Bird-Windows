using Flappy_Bird_Windows.Data.Config;
using Flappy_Bird_Windows.Forms;
using Flappy_Bird_Windows.Repository.Bird;
using Flappy_Bird_Windows.Repository.Pipe;
using Flappy_Bird_Windows.Service.BirdManager;
using Flappy_Bird_Windows.Service.PipeManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Flappy_Bird_Windows;

internal static class Program
{
    public static ServiceProvider? Services { get; private set; }
    public static Controls ControlsConfig { get; private set; } = new Controls();
    public static Gameplay GameplayConfig { get; private set; } = new Gameplay();

    [STAThread]
    static void Main()
    {
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
        RegisterServices();

        IConfiguration config = new ConfigurationBuilder().AddIniFile("config.ini").Build();
        config.GetSection(nameof(Controls)).Bind(ControlsConfig);
        config.GetSection(nameof(Gameplay)).Bind(GameplayConfig);

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
        Services = serviceCollection.BuildServiceProvider();
    }
}