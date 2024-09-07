using System.Runtime.InteropServices.JavaScript;

public static partial class GL
{
    [JSImport("ext.drawArraysInstancedANGLE", "main.js")]
    internal static partial void DrawArraysInstanced(int mode,
                                                     int first,
                                                     int count,
                                                     int instanceCount);

    [JSImport("ext.vertexAttribDivisorANGLE", "main.js")]
    internal static partial void VertexAttribDivisor(int index, int divisor);
}
