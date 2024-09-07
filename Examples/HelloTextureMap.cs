using System.Runtime.InteropServices.JavaScript;
using WebGL.Template.GameFramework;
using WebGL.Template.Interop;

namespace WebGL.Template.Examples;

/// <summary>
/// Demonstrates texture-mapping a quad.
/// The texture map has transparent pixels which allow the background color to show through.
/// An initial low-res texture is loaded first, then replaced with a high-res texture.
/// </summary>
public class HelloTextureMap : IGame
{
    private JSObject? _shaderProgram;

    public string? OverlayText => "Hello, Texture Map";

    public async Task LoadAssetsEssentialAsync(IShaderLoader shaderLoader)
    {
        // Load the shader program
        _shaderProgram = shaderLoader.LoadShaderProgram("BasicTextureMap/vertex", "BasicTextureMap/fragment");

        // Load the low-res texture
        string texturePath = "/textures/webgl-logo-lowres.png";

        // Load and bind texture
        var textureId = await LoadTexture(texturePath);
        GL.ActiveTexture(GL.TEXTURE0);
        GL.BindTexture(GL.TEXTURE_2D, textureId);
        var textureUniformLoc = GL.GetUniformLocation(_shaderProgram, "uTexture");
        GL.Uniform1i(textureUniformLoc, 0);
    }

    public void InitializeScene(IShaderLoader shaderLoader)
    {
        if (_shaderProgram is null)
            throw new InvalidOperationException("Shader program not loaded.");

        // POSITIONS
        // Create a buffer for the quad's vertex positions.
        var positionBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, positionBuffer);
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
        var positionAttributeLocation = GL.GetAttribLocation(_shaderProgram, "aVertexPosition");
        GL.VertexAttribPointer(positionAttributeLocation, 2, GL.FLOAT, false, 0, 0);
        GL.EnableVertexAttribArray(positionAttributeLocation);

        // TEXTURE COORDINATES
        // Create a buffer for the quad's texture coordinates.
        var textureCoordBuffer = GL.CreateBuffer();
        GL.BindBuffer(GL.ARRAY_BUFFER, textureCoordBuffer);
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
        var textureCoordAttributeLocation = GL.GetAttribLocation(_shaderProgram, "aTextureCoord");
        GL.VertexAttribPointer(textureCoordAttributeLocation, 2, GL.FLOAT, false, 0, 0);
        GL.EnableVertexAttribArray(textureCoordAttributeLocation);

        // Enable alpha blending for the textures which have an alpha channel
        GL.Enable(GL.BLEND);
        GL.BlendFunc(GL.SRC_ALPHA, GL.ONE_MINUS_SRC_ALPHA);

        // Set the clear color to cornflower blue
        GL.ClearColor(0.392f, 0.584f, 0.929f, 1.0f);
    }

    public async Task LoadAssetsExtendedAsync()
    {
        // Load the high-res texture
        string texturePath = "/textures/webgl-logo.png";

        // Load and bind texture
        var textureId = await LoadTexture(texturePath);
        GL.ActiveTexture(GL.TEXTURE0);
        GL.BindTexture(GL.TEXTURE_2D, textureId);

        // TODO: delete the low-res texture
    }

    public void Render()
    {
        GL.Clear(GL.COLOR_BUFFER_BIT);
        GL.DrawArrays(GL.TRIANGLE_STRIP, 0, 4);
    }

    private static async Task<JSObject> LoadTexture(string url)
    {
        // Load image using JS interop
        var image = await Utility.LoadImageFromUrl(url);
        var texture = GL.CreateTexture();
        GL.BindTexture(GL.TEXTURE_2D, texture);
        GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MIN_FILTER, GL.LINEAR_MIPMAP_LINEAR);
        GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MAG_FILTER, GL.LINEAR);
        GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_S, GL.CLAMP_TO_EDGE);
        GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_T, GL.CLAMP_TO_EDGE);
        GL.TexImage2D(GL.TEXTURE_2D, 0, GL.RGBA, GL.RGBA, GL.UNSIGNED_BYTE, image);
        GL.GenerateMipmap(GL.TEXTURE_2D);
        return texture;
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
