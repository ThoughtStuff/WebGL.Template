using System.Runtime.InteropServices;

namespace WebGL.Template.Examples.InstanceParticles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct InstanceData(Matrix3x2 transform, int spriteIndex)
{
    public Vector2 TransformRow0 = new(transform.M11, transform.M12);
    public Vector2 TransformRow1 = new(transform.M21, transform.M22);
    public Vector2 Translation = transform.Translation;
    public float SpriteIndex = spriteIndex;
}
