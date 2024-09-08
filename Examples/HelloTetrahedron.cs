using System.Runtime.InteropServices.JavaScript;
using WebGL.Template.GameFramework;

namespace WebGL.Template.Examples;

public class HelloTetrahedron : IGame
{
    private float _rotationAngleX = 0f;
    private float _rotationAngleY = 0f;
    private JSObject? _shaderProgram;
    private JSObject? _modelTransformLocation;

    public string? OverlayText => "Hello, Tetrahedron";

    public Task LoadAssetsEssentialAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader)
    {
        // No essential assets for this demo.
        return Task.CompletedTask;
    }

    public void InitializeScene(IShaderLoader shaderLoader)
    {
        // Load shader program from files using IShaderLoader
        _shaderProgram = shaderLoader.LoadShaderProgram("HelloTetrahedron/vertex", "HelloTetrahedron/fragment");

        // Store location of the model transform uniform
        _modelTransformLocation = GL.GetUniformLocation(_shaderProgram, "uModelTransform");

        // Define vertex positions for the tetrahedron
        Span<float> vertices =
        [
            .5f, .5f, .5f,
            -.5f, -.5f, .5f,
            -.5f, .5f, -.5f,

            .5f, -.5f, -.5f,
            -.5f, -.5f, .5f,
            -.5f, .5f, -.5f,

            .5f, .5f, .5f,
            -.5f, -.5f, .5f,
            .5f, -.5f, -.5f,

            .5f, .5f, .5f,
            .5f, -.5f, -.5f,
            -.5f, .5f, -.5f
        ];

        // Define colors for the vertices
        Span<float> colors =
        [
            // Vertex colors (RGB)
            1f, 0f, 0f,    // Red
            1f, 0f, 0f,    // Red
            1f, 0f, 0f,    // Red

            0f, 1f, 0f,    // Green
            0f, 1f, 0f,    // Green
            0f, 1f, 0f,    // Green

            0f, 0f, 1f,    // Blue
            0f, 0f, 1f,    // Blue
            0f, 0f, 1f,    // Blue

            1f, 1f, 0f,    // Yellow
            1f, 1f, 0f,    // Yellow
            1f, 1f, 0f     // Yellow
        ];

        // Create and bind the vertex buffer
        var positionBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, positionBuffer);
        GL.BufferData(GL.ARRAY_BUFFER, vertices, GL.STATIC_DRAW);

        var positionLocation = GL.GetAttribLocation(_shaderProgram, "aPosition");
        GL.EnableVertexAttribArray(positionLocation);
        GL.VertexAttribPointer(positionLocation, 3, GL.FLOAT, false, 0, 0);

        // Create and bind the color buffer
        var colorBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, colorBuffer);
        GL.BufferData(GL.ARRAY_BUFFER, colors, GL.STATIC_DRAW);

        var colorLocation = GL.GetAttribLocation(_shaderProgram, "aColor");
        GL.EnableVertexAttribArray(colorLocation);
        GL.VertexAttribPointer(colorLocation, 3, GL.FLOAT, false, 0, 0);

        // Enable depth testing
        GL.Enable(GL.DEPTH_TEST);

        // Set the clear color to black
        GL.ClearColor(0, 0, 0, 1);

        // Disable back face culling
        // GL.Disable(GL.CULL_FACE);
    }

    public Task LoadAssetsExtendedAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader)
    {
        // No extended assets for this demo.
        return Task.CompletedTask;
    }

    public void Update(TimeSpan deltaTime)
    {
        // Rotate the tetrahedron
        _rotationAngleX += (float)deltaTime.TotalSeconds * 15f; // Rotate 15 degrees per second
        _rotationAngleX %= 360f;
        _rotationAngleY += (float)deltaTime.TotalSeconds * 45f; // Rotate 45 degrees per second
        _rotationAngleY %= 360f;
    }

    public void FixedUpdate(TimeSpan deltaTime)
    {
        // Not needed for this demo
    }

    public void Render()
    {
        if (_shaderProgram is null || _modelTransformLocation is null)
        {
            throw new InvalidOperationException("Shader program or model transform location is null.");
        }

        GL.Clear(GL.COLOR_BUFFER_BIT | GL.DEPTH_BUFFER_BIT);
        GL.UseProgram(_shaderProgram);

        var modelTransformMatrix = Matrix4x4.CreateRotationY(ToRadians(_rotationAngleY))
            * Matrix4x4.CreateRotationX(ToRadians(_rotationAngleX));

        // Send model transform matrix to shader
        GL.UniformMatrix(_modelTransformLocation, false, ref modelTransformMatrix);

        // Draw the tetrahedron
        GL.DrawArrays(GL.TRIANGLES, 0, 12); // Assuming 12 vertices for 4 triangles (tetrahedron)
    }

    private static float ToRadians(float rotationAngle)
    {
        return rotationAngle * MathF.PI / 180f;
    }

    public void OnKeyPress(string key, bool pressed) { }

    public void OnMouseClick(int button, bool pressed, Vector2 position) { }

    public void OnMouseMove(Vector2 position) { }

    public void OnTouchStart(IEnumerable<Vector2> touches) { }

    public void OnTouchMove(IEnumerable<Vector2> touches) { }

    public void OnTouchEnd(IEnumerable<Vector2> touches) { }
}
