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
using System.Globalization;
using System.Reflection;

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

        LoadConfig();

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

    public static void LoadConfig()
    {
        var configFile = "config.ini";
        IConfiguration? config = null;
        try
        {
            config = new ConfigurationBuilder().AddIniFile(configFile).Build();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not find config file.{Environment.NewLine}{Environment.NewLine}{ex.Message}", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var configProperties = typeof(Program).GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Where(p => p.PropertyType.GetCustomAttributes(typeof(ConfigSectionAttribute), true).Length > 0);

        foreach (var property in configProperties)
        {
            var configObject = property.GetValue(null);
            var configType = property.PropertyType;
            var sectionAttr = (ConfigSectionAttribute)configType.GetCustomAttributes(typeof(ConfigSectionAttribute), true)[0];
            var sectionName = sectionAttr.SectionName;

            try
            {
                config.GetSection(sectionName).Bind(configObject);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load config section '{sectionName}'. Using default config instead.{Environment.NewLine}{Environment.NewLine}{ex.Message}", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public static void SaveConfig()
    {
        var configFile = "config.ini";
        using var writer = new StreamWriter(configFile);
        var configProperties = typeof(Program).GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Where(p => p.PropertyType.GetCustomAttributes(typeof(ConfigSectionAttribute), true).Length > 0);

        foreach (var property in configProperties)
        {
            var configObject = property.GetValue(null);
            var configType = property.PropertyType;
            var sectionAttr = (ConfigSectionAttribute)configType.GetCustomAttributes(typeof(ConfigSectionAttribute), true)[0];
            var sectionName = sectionAttr.SectionName;

            writer.WriteLine($"[{sectionName}]");

            var properties = configType.GetProperties();

            foreach (var prop in properties)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(configObject);

                writer.WriteLine($"{propName}={ConvertObjectToString(propValue)}");
            }

            writer.WriteLine();
        }
    }

    public static void ResetConfig()
    {
        ControlsConfig = new ControlsConfig();
        GameplayConfig = new GameplayConfig();
        ProgramConfig = new ProgramConfig();
        SaveConfig();
    }

    private static string? ConvertObjectToString(object? obj)
    {
        if (obj is bool)
        {
            return obj.ToString()?.ToLower();
        }
        else if (obj is float or double or decimal)
        {
            return Convert.ToString(obj, CultureInfo.InvariantCulture);
        }

        return obj?.ToString();
    }
}