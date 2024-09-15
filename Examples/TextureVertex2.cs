using System.Runtime.InteropServices;

namespace WebGL.Template.Examples;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct TextureVertex2(Vector2 position, Vector2 textureCoord)
{
    public Vector2 Position = position;
    public Vector2 TextureCoord = textureCoord;
}
