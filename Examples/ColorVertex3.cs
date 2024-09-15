using System.Runtime.InteropServices;

namespace WebGL.Template.Examples;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct ColorVertex3(Vector3 position, Vector3 color)
{
    public Vector3 Position = position;
    public Vector3 Color = color;
}
