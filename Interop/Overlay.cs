using System.Runtime.InteropServices.JavaScript;

namespace WebGL.Template.Interop;

static partial class Overlay
{
    [JSImport("overlay.setFPS", "main.js")]
    public static partial void SetFPS(string fps);

    [JSImport("overlay.setErrorMessage", "main.js")]
    public static partial void SetErrorMessage(string message);
}
