using System.Runtime.InteropServices;
using WebGL.Template.Interop;

static partial class GL
{
    /// <summary>
    /// Call gl.BufferData with the Span of given values which will be marshalled as bytes
    /// </summary>
    public static void BufferData<T>(int target, Span<T> data, int usage) where T : struct
    {
        // Marshal as bytes without copying
        Utility.GlBufferData(target, MemoryMarshal.AsBytes(data), usage);
    }
}
