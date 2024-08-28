using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;

public static partial class Utility
{
    [JSImport("utility.createFloat32Array", "main.js")]
    public static partial JSObject CreateFloat32Array(double[] array);

    [JSImport("utility.glBufferData", "main.js")]
    public static partial void GlBufferData(int target,
                                            [JSMarshalAs<MemoryView>] Span<byte> data,
                                            int usage);

    /// <summary>
    /// Call gl.BufferData with the given floats (marshalled as bytes)
    /// </summary>
    public static void GlBufferData(int target, Span<float> data, int usage)
    {
        // Marshal as bytes without copying
        GlBufferData(target, MemoryMarshal.AsBytes(data), usage);
    }
}
