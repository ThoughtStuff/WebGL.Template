using System.Runtime.InteropServices.JavaScript;

namespace WebGL.Template.GameFramework;

public interface IShaderLoader
{
    JSObject LoadShaderProgram(string vertexShaderName, string fragmentShaderName);
}
