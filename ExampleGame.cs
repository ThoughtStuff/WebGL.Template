using System.Numerics;

namespace WebGL.Template;

public class ExampleGame : IGameEngine
{
    public void Initialize(IShaderLoader shaderLoader)
    {
        throw new NotImplementedException();
    }

    public void Update(TimeSpan deltaTime)
    {
        throw new NotImplementedException();
    }

    public void FixedUpdate(TimeSpan deltaTime)
    {
        throw new NotImplementedException();
    }

    public void OnKeyPress(string key, bool pressed)
    {
        throw new NotImplementedException();
    }

    public void OnMouseClick(int button, bool pressed)
    {
        throw new NotImplementedException();
    }

    public void OnMouseMove(float x, float y)
    {
        throw new NotImplementedException();
    }

    public void Render()
    {
        GL.Clear(GL.COLOR_BUFFER_BIT);
        GL.DrawArrays(GL.TRIANGLES, 0, 3);
    }
}
