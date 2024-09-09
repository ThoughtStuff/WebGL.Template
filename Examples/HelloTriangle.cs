using WebGL.Template.GameFramework;

namespace WebGL.Template.Examples;

class HelloTriangle : IGame
{
    public string? OverlayText => "Hello, Triangle";

    public void InitializeScene(IShaderLoader shaderLoader)
    {
        // Load the shader program
        var shaderProgram = shaderLoader.LoadShaderProgram("vertex", "fragment");

        // POSITIONS
        // Create a buffer for the triangle's vertex positions.
        var positionBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, positionBuffer);
        // Define the vertex positions for the triangle. Assume NDC coordinates [-1 ... 1].
        Span<float> positions =
        [
            0.0f, 1.0f,
            -1.0f, -1.0f,
            1.0f, -1.0f
        ];
        GL.BufferData(GL.ARRAY_BUFFER, positions, GL.STATIC_DRAW);
        // Tell WebGL how to pull out the positions from the position buffer into the vertexPosition attribute.
        var positionAttributeLocation = GL.GetAttribLocation(shaderProgram, "a_VertexPosition");
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
        var colorAttributeLocation = GL.GetAttribLocation(shaderProgram, "a_VertexColor");
        GL.VertexAttribPointer(colorAttributeLocation, 4, GL.FLOAT, false, 0, 0);
        GL.EnableVertexAttribArray(colorAttributeLocation);

        // Set the clear color to cornflower blue
        GL.ClearColor(0.392f, 0.584f, 0.929f, 1.0f);
    }

    public void Render()
    {
        GL.Clear(GL.COLOR_BUFFER_BIT);
        GL.DrawArrays(GL.TRIANGLES, 0, 3);
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
