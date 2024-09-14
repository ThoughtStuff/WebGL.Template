using System.Runtime.InteropServices.JavaScript;
using ThoughtStuff.GLSourceGen;
using WebGL.Template.GameFramework;

namespace WebGL.Template.Examples;

sealed partial class HelloQuad : IGame
{
    private JSObject? _shaderProgram;
    private JSObject? _vertexBuffer;
    private readonly List<int> _vertexAttributeLocations = [];

    public string? OverlayText => "Hello, Quad";

    public void InitializeScene(IShaderLoader shaderLoader)
    {
        // Load the shader program
        _shaderProgram = shaderLoader.LoadShaderProgram("Basic/ColorPassthrough_vert", "Basic/ColorPassthrough_frag");

        // Define the vertex positions for the quad. Assume NDC coordinates [-1 ... 1].
        Span<ColorVertex2> vertices =
        [
            new(new(-1, 1), new(1, 0, 0, 1)),   // Red
            new(new(-1, -1), new(0, 1, 0, 1)),  // Green
            new(new(1, 1), new(0, 0, 1, 1)),    // Blue
            new(new(1, -1), new(1, 1, 0, 1))    // Yellow
        ];
        // Create a buffer for the quad's vertices
        _vertexBuffer = GL.CreateBuffer();
        SetVertexBufferData(_shaderProgram, _vertexBuffer, vertices, _vertexAttributeLocations);

        // Set the clear color to cornflower blue
        GL.ClearColor(0.392f, 0.584f, 0.929f, 1.0f);
    }

    [SetupVertexAttrib("Shaders/Basic/ColorPassthrough_vert.glsl")]
    partial void SetVertexBufferData(JSObject shaderProgram,
                                     JSObject vertexBuffer,
                                     Span<ColorVertex2> vertices,
                                     List<int> vertexAttributeLocations);

    public void Dispose()
    {
        // Disable all vertex attribute locations
        foreach (var attributeLocation in _vertexAttributeLocations)
        {
            GL.DisableVertexAttribArray(attributeLocation);
        }
        _vertexAttributeLocations.Clear();

        // Delete the position buffer
        if (_vertexBuffer is not null)
        {
            GL.DeleteBuffer(_vertexBuffer);
            _vertexBuffer.Dispose();
            _vertexBuffer = null;
        }

        // Delete the shader program
        if (_shaderProgram is not null)
            ShaderLoader.DisposeShaderProgram(_shaderProgram);
        _shaderProgram = null;
    }

    public void Render()
    {
        GL.Clear(GL.COLOR_BUFFER_BIT);
        if (_vertexBuffer is not null)
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
