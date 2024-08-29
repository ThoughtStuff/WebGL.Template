using System.Runtime.InteropServices.JavaScript;

// Global namespace to make JS consumption easy

public static partial class InputInterop
{
    [JSExport]
    public static void OnKeyDown(string keyName, bool shift, bool ctrl, bool alt, bool repeat)
    {
    }

    [JSExport]
    public static void OnKeyUp(string keyName, bool shift, bool ctrl, bool alt)
    {
    }

    [JSExport]
    public static void OnMouseMove(float x, float y)
    {
    }

    [JSExport]
    public static void OnMouseDown(bool shift, bool ctrl, bool alt, int button)
    {
    }

    [JSExport]
    public static void OnMouseUp(bool shift, bool ctrl, bool alt, int button)
    {
    }
}
