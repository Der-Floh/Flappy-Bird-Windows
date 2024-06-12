using Flappy_Bird_Windows.Config;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Flappy_Bird_Windows;

internal static class Program
{
    public static Controls ControlsConfig { get; private set; } = new Controls();
    public static Gameplay GameplayConfig { get; private set; } = new Gameplay();

    [STAThread]
    static void Main()
    {
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

        IConfiguration config = new ConfigurationBuilder().AddIniFile("config.ini").Build();
        config.GetSection(nameof(Controls)).Bind(ControlsConfig);
        config.GetSection(nameof(Gameplay)).Bind(GameplayConfig);

        ApplicationConfiguration.Initialize();
        Application.Run(new Game());
    }
}