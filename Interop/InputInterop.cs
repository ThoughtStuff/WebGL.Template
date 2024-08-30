using System.Runtime.InteropServices.JavaScript;
using WebGL.Template;

// Global namespace to make JS consumption easy

public static partial class InputInterop
{
    [JSExport]
    public static void OnKeyDown(string keyName, bool shift, bool ctrl, bool alt, bool repeat)
    {
        GameSingleton.Instance?.OnKeyPress(keyName, true);
    }

    [JSExport]
    public static void OnKeyUp(string keyName, bool shift, bool ctrl, bool alt)
    {
        GameSingleton.Instance?.OnKeyPress(keyName, false);
    }

    [JSExport]
    public static void OnMouseMove(float x, float y)
    {
        GameSingleton.Instance?.OnMouseMove(x, y);
    }

    [JSExport]
    public static void OnMouseDown(bool shift, bool ctrl, bool alt, int button, float x, float y)
    {
        GameSingleton.Instance?.OnMouseClick(button, true, x, y);
    }

    [JSExport]
    public static void OnMouseUp(bool shift, bool ctrl, bool alt, int button, float x, float y)
    {
        GameSingleton.Instance?.OnMouseClick(button, false, x, y);
    }

    [JSExport]
    public static void OnTouchStart(float x, float y)
    {
        GameSingleton.Instance?.OnTouchStart(x, y);
    }

    [JSExport]
    public static void OnTouchMove(float x, float y)
    {
        GameSingleton.Instance?.OnTouchMove(x, y);
    }

    [JSExport]
    public static void OnTouchEnd()
    {
        GameSingleton.Instance?.OnTouchEnd();
    }
}
