using Microsoft.Extensions.DependencyInjection;

namespace Flappy_Bird_Windows.Utility;

/// <summary>
/// Resolves form constructor dependencies from DI while forwarding any extra
/// arguments (e.g. a Color enum value) that are not registered in the container.
/// </summary>
public sealed class FormFactory(IServiceProvider serviceProvider) : IFormFactory
{
    public TForm Create<TForm>(params object[] extraArgs) where TForm : Form
        => (TForm)ActivatorUtilities.CreateInstance(serviceProvider, typeof(TForm), extraArgs);
}
