using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebGL.Template.Interop;

static partial class Utility
{
    /// <summary>
    /// This should not be called directly.
    /// It is used as part of the shim and called by GL.BufferData
    /// </summary>
    [JSImport("utility.glBufferData", "main.js")]
    public static partial void GlBufferData(int target,
                                            [JSMarshalAs<MemoryView>] Span<byte> data,
                                            int usage);

    /// <summary>
    /// Use JavaScript to load an image from a URL.
    /// The URL can be relative or absolute.
    /// </summary>
    [JSImport("utility.loadImageFromUrl", "main.js")]
    internal static partial Task<JSObject> LoadImageFromUrl(string url);
}
