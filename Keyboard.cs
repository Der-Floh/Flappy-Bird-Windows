using System.Runtime.InteropServices;

namespace Flappy_Bird_Windows;

public abstract class Keyboard
{
    [Flags]
    private enum KeyStates
    {
        None = 0,
        Down = 1,
        Toggled = 2
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    private static extern short GetKeyState(int keyCode);

    private static KeyStates GetKeyState(Keys key)
    {
        var state = KeyStates.None;

        var retVal = GetKeyState((int)key);

        //If the high-order bit is 1, the key is down
        //otherwise, it is up.
        if ((retVal & 0x8000) == 0x8000)
            state |= KeyStates.Down;

        //If the low-order bit is 1, the key is toggled.
        if ((retVal & 1) == 1)
            state |= KeyStates.Toggled;

        return state;
    }

    public static bool IsKeyDown(Keys key) => KeyStates.Down == (GetKeyState(key) & KeyStates.Down);

    public static bool IsKeyToggled(Keys key) => KeyStates.Toggled == (GetKeyState(key) & KeyStates.Toggled);

    public static bool IsKeyUp(Keys key) => KeyStates.None == (GetKeyState(key) & KeyStates.Down);
}