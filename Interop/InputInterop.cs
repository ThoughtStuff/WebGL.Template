using System.Runtime.InteropServices.JavaScript;
using WebGL.Template.GameFramework;

// Global namespace to make JS consumption easy

static partial class InputInterop
{
    [JSExport]
    public static void OnKeyDown(string keyName, bool shift, bool ctrl, bool alt)
    {
        Singletons.GameInstance?.OnKeyPress(keyName, pressed: true);
    }

    [JSExport]
    public static void OnKeyUp(string keyName, bool shift, bool ctrl, bool alt)
    {
        Singletons.GameInstance?.OnKeyPress(keyName, pressed: false);
    }

    [JSExport]
    public static void OnMouseMove(float x, float y)
    {
        Singletons.GameInstance?.OnMouseMove(new(x, y));
    }

    [JSExport]
    public static void OnMouseDown(bool shift, bool ctrl, bool alt, int button, float x, float y)
    {
        Singletons.GameInstance?.OnMouseClick(button, true, new(x, y));
    }

    [JSExport]
    public static void OnMouseUp(bool shift, bool ctrl, bool alt, int button, float x, float y)
    {
        Singletons.GameInstance?.OnMouseClick(button, false, new(x, y));
    }

    [JSExport]
    public static void OnTouchStart(JSObject[] touches)
    {
        var vectors = ToVector2s(touches);
        Singletons.GameInstance?.OnTouchStart(vectors);
    }

    [JSExport]
    public static void OnTouchMove(JSObject[] touches)
    {
        var vectors = ToVector2s(touches);
        Singletons.GameInstance?.OnTouchMove(vectors);
    }

    [JSExport]
    public static void OnTouchEnd(JSObject[] touches)
    {
        var vectors = ToVector2s(touches);
        Singletons.GameInstance?.OnTouchEnd(vectors);
    }

    private static IEnumerable<Vector2> ToVector2s(JSObject[] touches)
    {
        return touches.Select(touch =>
            new Vector2((float)touch.GetPropertyAsDouble("x"),
                        (float)touch.GetPropertyAsDouble("y")));
    }
}
