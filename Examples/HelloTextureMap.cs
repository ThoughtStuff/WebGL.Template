using System.Runtime.InteropServices.JavaScript;
using WebGL.Template.GameFramework;

namespace WebGL.Template.Examples;

/// <summary>
/// Demonstrates texture-mapping a quad.
/// The texture map has transparent pixels which allow the background color to show through.
/// An initial low-res texture is loaded first, then replaced with a high-res texture.
/// </summary>
sealed class HelloTextureMap : IGame
{
    private JSObject? _shaderProgram;
    private JSObject? _lowResTextureId;
    private JSObject? _highResTextureId;
    private JSObject? _positionBuffer;
    private JSObject? _textureCoordBuffer;

    public string? OverlayText => "Hello, Texture Map";

    public async Task LoadAssetsEssentialAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader)
    {
        // Load the shader program
        _shaderProgram = shaderLoader.LoadShaderProgram("Basic/TextureUnlit_vert", "Basic/TextureUnlit_frag");

        // Load the low-res texture
        string texturePath = "/textures/webgl-logo-lowres.png";

        // Load and bind texture
        var textureId = await textureLoader.LoadTexture(texturePath,
                                                        mipMapping: false,
                                                        nearestNeighborMagnification: false);
        GL.ActiveTexture(GL.TEXTURE0);
        GL.BindTexture(GL.TEXTURE_2D, textureId);
        var textureUniformLoc = GL.GetUniformLocation(_shaderProgram, "u_Texture");
        GL.Uniform1i(textureUniformLoc, 0);

        _lowResTextureId = textureId;
    }

    public void InitializeScene(IShaderLoader shaderLoader)
    {
        if (_shaderProgram is null)
            throw new InvalidOperationException("Shader program not loaded.");

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

        // TEXTURE COORDINATES
        // Create a buffer for the quad's texture coordinates.
        _textureCoordBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, _textureCoordBuffer);
        // Define the texture coordinates for each vertex of the quad.
        Span<float> textureCoords =
        [
            0.0f, 0.0f,
            0.0f, 1.0f,
            1.0f, 0.0f,
            1.0f, 1.0f
        ];
        GL.BufferData(GL.ARRAY_BUFFER, textureCoords, GL.STATIC_DRAW);
        // Tell WebGL how to pull out the texture coordinates from the textureCoord buffer into the textureCoord attribute.
        var textureCoordAttributeLocation = GL.GetAttribLocation(_shaderProgram, "a_TextureCoord");
        GL.VertexAttribPointer(textureCoordAttributeLocation, 2, GL.FLOAT, false, 0, 0);
        GL.EnableVertexAttribArray(textureCoordAttributeLocation);

        // Enable alpha blending for the textures which have an alpha channel
        GL.Enable(GL.BLEND);
        GL.BlendFunc(GL.SRC_ALPHA, GL.ONE_MINUS_SRC_ALPHA);

        // Set the clear color to cornflower blue
        GL.ClearColor(0.392f, 0.584f, 0.929f, 1.0f);
    }

    public async Task LoadAssetsExtendedAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader)
    {
        // Load the high-res texture
        string texturePath = "/textures/webgl-logo.png";

        // Load and bind texture
        var textureId = await textureLoader.LoadTexture(texturePath);
        GL.ActiveTexture(GL.TEXTURE0);
        GL.BindTexture(GL.TEXTURE_2D, textureId);
        _highResTextureId = textureId;

        // Delete the low-res texture
        if (_lowResTextureId is not null)
        {
            GL.DeleteTexture(_lowResTextureId);
            _lowResTextureId.Dispose();
            _lowResTextureId = null;
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

    public void Dispose()
    {
        // Delete the position buffer
        if (_positionBuffer is not null)
        {
            GL.DeleteBuffer(_positionBuffer);
            _positionBuffer.Dispose();
            _positionBuffer = null;
        }

        // Delete the texture coordinate buffer
        if (_textureCoordBuffer is not null)
        {
            GL.DeleteBuffer(_textureCoordBuffer);
            _textureCoordBuffer.Dispose();
            _textureCoordBuffer = null;
        }

        // Delete the low-res texture if it hasn't been deleted already
        if (_lowResTextureId is not null)
        {
            GL.DeleteTexture(_lowResTextureId);
            _lowResTextureId.Dispose();
            _lowResTextureId = null;
        }

        // Delete the high-res texture if it hasn't been deleted already
        if (_highResTextureId is not null)
        {
            GL.DeleteTexture(_highResTextureId);
            _highResTextureId.Dispose();
            _highResTextureId = null;
        }

        // Delete the shader program
        if (_shaderProgram is not null)
        {
            GL.DeleteProgram(_shaderProgram);
            _shaderProgram.Dispose();
            _shaderProgram = null;
        }
    }

    public void Update(TimeSpan deltaTime) { }
    public void FixedUpdate(TimeSpan deltaTime) { }
    public void OnKeyPress(string key, bool pressed) { }
    public void OnMouseClick(int button, bool pressed, Vector2 position) { }
    public void OnMouseMove(Vector2 position) { }
    public void OnTouchEnd(IEnumerable<Vector2> touches) { }
    public void OnTouchMove(IEnumerable<Vector2> touches) { }
    public void OnTouchStart(IEnumerable<Vector2> touches) { }
}
