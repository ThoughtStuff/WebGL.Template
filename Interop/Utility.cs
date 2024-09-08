using System.Runtime.InteropServices;
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

    [JSImport("utility.bytesToFloat32Array", "main.js")]
    internal static partial JSObject ToFloat32Array([JSMarshalAs<MemoryView>] Span<byte> data);

    /// <summary>
    /// Create a Float32Array from a Matrix4x4
    /// without copying the data.
    /// </summary>
    internal static JSObject ToFloat32Array(ref Matrix4x4 modelMatrix)
    {
        var matSpan = MemoryMarshal.CreateSpan(ref modelMatrix, 1);
        var floatSpan = MemoryMarshal.Cast<Matrix4x4, float>(matSpan);
        var byteSpan = MemoryMarshal.AsBytes(floatSpan);
        return ToFloat32Array(byteSpan);
    }
}
