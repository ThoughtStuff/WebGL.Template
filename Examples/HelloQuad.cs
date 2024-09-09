using System.Runtime.InteropServices.JavaScript;
using WebGL.Template.GameFramework;

namespace WebGL.Template.Examples;

sealed class HelloQuad : IGame
{
    private JSObject? _shaderProgram;
    private JSObject? _positionBuffer;
    private JSObject? _colorBuffer;

    public string? OverlayText => "Hello, Quad";

    public void InitializeScene(IShaderLoader shaderLoader)
    {
        // Load the shader program
        _shaderProgram = shaderLoader.LoadShaderProgram("Basic/ColorPassthrough_vert", "Basic/ColorPassthrough_frag");

        // POSITIONS
        // Create a buffer for the quad's vertex positions.
        _positionBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, _positionBuffer);
        // Define the vertex positions for the quad. Assume NDC coordinates [-1 ... 1].
        Span<float> positions =
        [
            -1.0f, 1.0f,
            -1.0f, -1.0f,
            1.0f, 1.0f,
            1.0f, -1.0f
        ];
        GL.BufferData(GL.ARRAY_BUFFER, positions, GL.STATIC_DRAW);
        // Tell WebGL how to pull out the positions from the position buffer into the vertexPosition attribute.
        var positionAttributeLocation = GL.GetAttribLocation(_shaderProgram, "a_VertexPosition");
        GL.VertexAttribPointer(positionAttributeLocation, 2, GL.FLOAT, false, 0, 0);
        GL.EnableVertexAttribArray(positionAttributeLocation);

        // COLORS
        // Create a buffer for the quad's colors.
        _colorBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, _colorBuffer);
        // Define the colors for each vertex of the quad (Rainbow: Red, Green, Blue, Yellow).
        Span<float> colors =
        [
            1.0f, 0.0f, 0.0f, 1.0f, // Red
            0.0f, 1.0f, 0.0f, 1.0f, // Green
            0.0f, 0.0f, 1.0f, 1.0f, // Blue
            1.0f, 1.0f, 0.0f, 1.0f  // Yellow
        ];
        GL.BufferData(GL.ARRAY_BUFFER, colors, GL.STATIC_DRAW);
        // Tell WebGL how to pull out the colors from the color buffer into the vertexColor attribute.
        var colorAttributeLocation = GL.GetAttribLocation(_shaderProgram, "a_VertexColor");
        GL.VertexAttribPointer(colorAttributeLocation, 4, GL.FLOAT, false, 0, 0);
        GL.EnableVertexAttribArray(colorAttributeLocation);

        // Set the clear color to cornflower blue
        GL.ClearColor(0.392f, 0.584f, 0.929f, 1.0f);
    }

    public void Dispose()
    {
        // Delete the position buffer
        if (_positionBuffer is not null)
        {
            GL.DeleteBuffer(_positionBuffer);
            _positionBuffer.Dispose();
            _positionBuffer = null;
        }

        // Delete the color buffer
        if (_colorBuffer is not null)
        {
            GL.DeleteBuffer(_colorBuffer);
            _colorBuffer.Dispose();
            _colorBuffer = null;
        }

        // Delete the shader program
        if (_shaderProgram is not null)
        {
            GL.DeleteProgram(_shaderProgram);
            _shaderProgram.Dispose();
            _shaderProgram = null;
        }
    }

    public void Render()
    {
        GL.Clear(GL.COLOR_BUFFER_BIT);
        if (_positionBuffer is not null)
        {
            GL.DrawArrays(GL.TRIANGLE_STRIP, 0, 4);
        }
    }

    public Task LoadAssetsEssentialAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader) => Task.CompletedTask;
    public Task LoadAssetsExtendedAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader) => Task.CompletedTask;
    public void Update(TimeSpan deltaTime) { }
    public void FixedUpdate(TimeSpan deltaTime) { }
    public void OnKeyPress(string key, bool pressed) { }
    public void OnMouseClick(int button, bool pressed, Vector2 position) { }
    public void OnMouseMove(Vector2 position) { }
    public void OnTouchEnd(IEnumerable<Vector2> touches) { }
    public void OnTouchMove(IEnumerable<Vector2> touches) { }
    public void OnTouchStart(IEnumerable<Vector2> touches) { }
}
