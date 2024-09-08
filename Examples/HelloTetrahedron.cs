using System.Runtime.InteropServices.JavaScript;
using WebGL.Template.GameFramework;

namespace WebGL.Template.Examples;

public class HelloTetrahedron : IGame
{
    private float _rotationAngleX = 0f;
    private float _rotationAngleY = 0f;
    private JSObject? _shaderProgram;
    private JSObject? _modelViewLocation;
    private JSObject? _projectionLocation;

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

        // Store location of the model-view and projection matrix uniforms
        _modelViewLocation = GL.GetUniformLocation(_shaderProgram, "uModelViewMatrix");
        _projectionLocation = GL.GetUniformLocation(_shaderProgram, "uProjectionMatrix");

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
    }

    public Task LoadAssetsExtendedAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader)
    {
        // No extended assets for this demo.
        return Task.CompletedTask;
    }

    public void Update(TimeSpan deltaTime)
    {
        // Rotate the tetrahedron
        _rotationAngleX += (float)deltaTime.TotalSeconds * 30;
        _rotationAngleX %= 360f;
        _rotationAngleY += (float)deltaTime.TotalSeconds * 120;
        _rotationAngleY %= 360f;
    }

    public void FixedUpdate(TimeSpan deltaTime)
    {
        // Not needed for this demo
    }

    public void Render()
    {
        if (_shaderProgram is null || _modelViewLocation is null || _projectionLocation is null)
        {
            throw new InvalidOperationException("Shader program or matrix locations are null.");
        }

        GL.Clear(GL.COLOR_BUFFER_BIT | GL.DEPTH_BUFFER_BIT);
        GL.UseProgram(_shaderProgram);

        // Create Model-View matrix (rotation)
        var modelViewMatrix = Matrix4x4.CreateRotationY(ToRadians(_rotationAngleY)) *
                              Matrix4x4.CreateRotationX(ToRadians(_rotationAngleX)) *
                              Matrix4x4.CreateTranslation(0, 0, -2);

        // Create Projection matrix (perspective projection)
        var projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(
            fieldOfView: ToRadians(60),
            aspectRatio: 1.0f,           // TODO: Fix aspect ratio
            nearPlaneDistance: 0.1f,
            farPlaneDistance: 10
        );

        // Send model-view and projection matrices to the shader
        GL.UniformMatrix(_modelViewLocation, false, ref modelViewMatrix);
        GL.UniformMatrix(_projectionLocation, false, ref projectionMatrix);

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
