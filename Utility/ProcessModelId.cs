using System.Runtime.InteropServices;

namespace Flappy_Bird_Windows.Utility;

public static class ProcessModelId
{
    [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int SetCurrentProcessExplicitAppUserModelID(string AppID);

}
