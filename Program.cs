using System.Runtime.InteropServices.JavaScript;
using WebGL.Template;

Console.WriteLine("Hello, from C#!");

// Vertex shader program
string vsSource = ResourceLoading.LoadEmbeddedResourceText("Shaders/vertex.glsl");
var vertexShader = LoadShader(GL.VERTEX_SHADER, vsSource);

// Load and compile the fragment shader
string fsSource = ResourceLoading.LoadEmbeddedResourceText("Shaders/fragment.glsl");
var fragmentShader = LoadShader(GL.FRAGMENT_SHADER, fsSource);

// Create and link the shader program
var shaderProgram = GL.CreateProgram();
GL.AttachShader(shaderProgram, vertexShader);
GL.AttachShader(shaderProgram, fragmentShader);
GL.LinkProgram(shaderProgram);
if (!GL.GetProgramParameter(shaderProgram, GL.LINK_STATUS))
{
    throw new Exception("Unable to initialize the shader program: " + GL.GetProgramInfoLog(shaderProgram));
}
GL.UseProgram(shaderProgram);

// POSITIONS
// Create a buffer for the triangle's vertex positions.
var positionBuffer = GL.CreateBuffer();
GL.BindBuffer(GL.ARRAY_BUFFER, positionBuffer);
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

// Draw the triangle
GL.DrawArrays(GL.TRIANGLES, 0, 3);

// Function to load and compile shaders
static JSObject LoadShader(int type, string source)
{
    var shader = GL.CreateShader(type);
    GL.ShaderSource(shader, source);
    GL.CompileShader(shader);

    if (!GL.GetShaderParameter(shader, GL.COMPILE_STATUS))
    {
        GL.DeleteShader(shader);
        throw new Exception("An error occurred compiling the shaders.");
    }

    return shader;
}

public partial class MyClass
{
    [JSExport]
    internal static string Greeting()
    {
        return "Hello, WebGL!";
    }
}
