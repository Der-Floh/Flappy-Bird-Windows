namespace Flappy_Bird_Windows.Utility;

/// <summary>
/// Creates Windows Forms instances with all their dependencies resolved
/// via the DI container, while still accepting extra constructor arguments
/// (e.g. the Color passed to BirdForm).
/// </summary>
public interface IFormFactory
{
    /// <summary>Creates a form whose dependencies are fully injected by DI.</summary>
    TForm Create<TForm>(params object[] extraArgs) where TForm : Form;
}
