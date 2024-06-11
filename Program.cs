using Flappy_Bird_Windows.Config;
using Microsoft.Extensions.Configuration;

namespace Flappy_Bird_Windows;

internal static class Program
{
    public static Controls ControlsConfig { get; private set; } = new Controls();
    public static GamePlay GamePlayConfig { get; private set; } = new GamePlay();

    [STAThread]
    static void Main()
    {
        IConfiguration config = new ConfigurationBuilder().AddIniFile("config.ini").Build();
        config.GetSection(nameof(Controls)).Bind(ControlsConfig);
        config.GetSection(nameof(GamePlay)).Bind(GamePlayConfig);

        ApplicationConfiguration.Initialize();
        Application.Run(new Game());
    }
}