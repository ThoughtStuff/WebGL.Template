using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace WebGL.Template;

public class ExampleGame : IGame
{
    private Vector2? _mousePosition;
    private JSObject? _positionBuffer;

    public void Initialize(IShaderLoader shaderLoader)
    {
        // Load the shader program
        var shaderProgram = shaderLoader.LoadShaderProgram("vertex", "fragment");

        // POSITIONS
        // Create a buffer for the triangle's vertex positions.
        _positionBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, _positionBuffer);
        // Define the vertex positions for the triangle.
        Span<float> positions =
        [
            0.0f, 1.0f,
            -1.0f, -1.0f,
            1.0f, -1.0f
        ];
        GL.BufferData(GL.ARRAY_BUFFER, positions, GL.STATIC_DRAW);
        // Tell WebGL how to pull out the positions from the position buffer into the vertexPosition attribute.
        var positionAttributeLocation = GL.GetAttribLocation(shaderProgram, "aVertexPosition");
        GL.VertexAttribPointer(positionAttributeLocation, 2, GL.FLOAT, false, 0, 0);
        GL.EnableVertexAttribArray(positionAttributeLocation);

        // COLORS
        // Create a buffer for the triangle's colors.
        var colorBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, colorBuffer);
        // Define the colors for each vertex of the triangle (Rainbow: Red, Green, Blue).
        Span<float> colors =
        [
            1.0f, 0.0f, 0.0f, 1.0f, // Red
            0.0f, 1.0f, 0.0f, 1.0f, // Green
            0.0f, 0.0f, 1.0f, 1.0f  // Blue
        ];
        GL.BufferData(GL.ARRAY_BUFFER, colors, GL.STATIC_DRAW);
        // Tell WebGL how to pull out the colors from the color buffer into the vertexColor attribute.
        var colorAttributeLocation = GL.GetAttribLocation(shaderProgram, "aVertexColor");
        GL.VertexAttribPointer(colorAttributeLocation, 4, GL.FLOAT, false, 0, 0);
        GL.EnableVertexAttribArray(colorAttributeLocation);

        // Set the clear color to cornflower blue
        GL.ClearColor(0.39f, 0.58f, 0.93f, 1.0f);
        GL.Clear(GL.COLOR_BUFFER_BIT);
    }

    public void Update(TimeSpan deltaTime)
    {
        if (_positionBuffer is null || _mousePosition is null)
            return;
        GL.BindBuffer(GL.ARRAY_BUFFER, _positionBuffer);
        // Transform [0, 1] to Normalized Device Coordinates (NDC) [-1, 1]
        // To match WebGL's default coordinates
        var x = _mousePosition.Value.X * 2 - 1;
        var y = _mousePosition.Value.Y * 2 - 1;
        Span<float> positions =
        [
            x, y,
            -1.0f, -1.0f,
            1.0f, -1.0f
        ];
        GL.BufferData(GL.ARRAY_BUFFER, positions, GL.STATIC_DRAW);
    }

    public void FixedUpdate(TimeSpan deltaTime)
    {
    }

    public void OnKeyPress(string key, bool pressed)
    {
    }

    public void OnMouseClick(int button, bool pressed)
    {
    }

    public void OnMouseMove(float x, float y)
    {
        _mousePosition = new Vector2(x, y);
    }

    public void Render()
    {
        GL.Clear(GL.COLOR_BUFFER_BIT);
        GL.DrawArrays(GL.TRIANGLES, 0, 3);
    }
}