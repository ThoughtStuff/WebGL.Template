using System.Runtime.InteropServices.JavaScript;

namespace WebGL.Template;

class ShaderLoader : IShaderLoader
{
    public JSObject LoadShaderProgram(string vertexShaderName, string fragmentShaderName)
    {
        var vertexShaderPath = GetPath(vertexShaderName);
        var vertexShaderSource = ResourceLoading.LoadEmbeddedResourceText(vertexShaderPath);
        var vertexShader = LoadShader(GL.VERTEX_SHADER, vertexShaderSource);
        var fragmentShaderPath = GetPath(fragmentShaderName);
        var fragmentShaderSource = ResourceLoading.LoadEmbeddedResourceText(fragmentShaderPath);
        var fragmentShader = LoadShader(GL.FRAGMENT_SHADER, fragmentShaderSource);

        // Create and link the shader program
        var shaderProgram = GL.CreateProgram();
        GL.AttachShader(shaderProgram, vertexShader);
        GL.AttachShader(shaderProgram, fragmentShader);
        GL.LinkProgram(shaderProgram);
        if (!GL.GetProgramParameterBool(shaderProgram, GL.LINK_STATUS))
        {
            throw new Exception("Unable to initialize the shader program: " + GL.GetProgramInfoLog(shaderProgram));
        }
        GL.UseProgram(shaderProgram);
        return shaderProgram;
    }

    private static string GetPath(string shaderName)
    {
        var shaderPath = $"Shaders/{shaderName}";
        if (!Path.HasExtension(shaderPath))
        {
            shaderPath += ".glsl";
        }
        return shaderPath;
    }

    internal static JSObject LoadShader(int type, string source)
    {
        var shader = GL.CreateShader(type);
        GL.ShaderSource(shader, source);
        GL.CompileShader(shader);

        if (!GL.GetShaderParameterBool(shader, GL.COMPILE_STATUS))
        {
            GL.DeleteShader(shader);
            throw new Exception("An error occurred compiling the shaders.");
        }

        return shader;
    }
}
