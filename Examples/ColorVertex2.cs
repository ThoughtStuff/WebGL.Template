using System.Runtime.InteropServices;

namespace WebGL.Template.Examples;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct ColorVertex2(Vector2 position, Vector4 color)
{
    public Vector2 Position = position;
    public Vector4 Color = color;
}
