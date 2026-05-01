using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

using Flappy_Bird_Windows.Data.Config;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Service.Config;

public sealed class ConfigService : IConfigService
{
    private readonly GameplayConfig _gameplay;
    private readonly ControlsConfig _controls;
    private readonly ProgramConfig _program;
    private readonly ILogger<ConfigService> _logger;

    public ConfigService(IOptions<GameplayConfig> gameplay, IOptions<ControlsConfig> controls, IOptions<ProgramConfig> program, ILogger<ConfigService> logger)
    {
        _gameplay = gameplay.Value;
        _controls = controls.Value;
        _program = program.Value;
        _logger = logger;
    }

    public bool Save()
    {
        try
        {
            WriteConfigToFile("config.ini");
            return true;
        }
        catch (UnauthorizedAccessException)
        {
            var tempFile = Path.GetTempFileName();
            WriteConfigToFile(tempFile);

            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c move /Y \"{tempFile}\" \"{Path.GetFullPath("config.ini")}\"",
                Verb = "runas",
                UseShellExecute = true,
                CreateNoWindow = true,
            };

            try
            {
                var process = Process.Start(startInfo);
                process?.WaitForExit();

                if (process?.ExitCode != 0)
                {
                    MessageBox.Show("Could not save config. Please try again later.", "Save Config",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Aborted.", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error saving config");
            return false;
        }
    }

    public void Reset()
    {
        CopyDefaults(_gameplay, new GameplayConfig());
        CopyDefaults(_controls, new ControlsConfig());
        CopyDefaults(_program, new ProgramConfig());
        Save();
    }

    private void WriteConfigToFile(string path)
    {
        object[] configObjects = [_gameplay, _controls, _program];
        using var writer = new StreamWriter(path);

        foreach (var configObject in configObjects)
        {
            var configType = configObject.GetType();
            var sectionAttr = (ConfigSectionAttribute)configType.GetCustomAttributes(typeof(ConfigSectionAttribute), true)[0];
            writer.WriteLine($"[{sectionAttr.SectionName}]");

            foreach (var prop in configType.GetProperties())
            {
                writer.WriteLine($"{prop.Name}={ConvertObjectToString(prop.GetValue(configObject))}");
            }

            writer.WriteLine();
        }
    }

    private static void CopyDefaults<T>(T target, T defaults) where T : class
    {
        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                     .Where(p => p.CanWrite))
        {
            prop.SetValue(target, prop.GetValue(defaults));
        }
    }

    private static string? ConvertObjectToString(object? obj)
    {
        if (obj is bool)
            return obj.ToString()?.ToLower();

        if (obj is float or double or decimal)
            return Convert.ToString(obj, CultureInfo.InvariantCulture);

        return obj?.ToString();
    }
}
