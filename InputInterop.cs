using System.Runtime.InteropServices.JavaScript;

public static partial class InputInterop
{
    [JSExport]
    public static void OnKeyDown(bool shift, bool ctrl, bool alt, bool repeat, int code)
    {
    }

    [JSExport]
    public static void OnKeyUp(bool shift, bool ctrl, bool alt, int code)
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
