using System.Runtime.InteropServices.JavaScript;

namespace WebGL.Template;

public interface IShaderLoader
{
    JSObject LoadShaderProgram(string vertexShaderName, string fragmentShaderName);
}
