using System.Runtime.InteropServices.JavaScript;

public static partial class RenderLoop
{
    [JSExport]
    public static void Render()
    {
        GL.Clear(GL.COLOR_BUFFER_BIT);
        GL.DrawArrays(GL.TRIANGLES, 0, 3);
        // NOTE: If you throw an exception here it will kill the render loop
    }
}
