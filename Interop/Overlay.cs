using System.Runtime.InteropServices.JavaScript;
using WebGL.Template;

// Global namespace to make JS consumption easy

static partial class Overlay
{
    [JSImport("overlay.setFPS", "main.js")]
    public static partial void SetFPS(string fps);

    [JSImport("overlay.setErrorMessage", "main.js")]
    public static partial void SetErrorMessage(string message);

    [JSExport]
    public static void ClearErrorMessage()
    {
        Singletons.OverlayHandlerInstance?.ClearErrorMessage();
    }
}
