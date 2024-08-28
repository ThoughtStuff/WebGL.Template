using System.Runtime.InteropServices.JavaScript;

public static partial class GL
{
    [JSImport("gl.createShader", "main.js")]
    internal static partial JSObject CreateShader(int type);

    [JSImport("gl.shaderSource", "main.js")]
    internal static partial void ShaderSource(JSObject shader, string source);

    [JSImport("gl.compileShader", "main.js")]
    internal static partial void CompileShader(JSObject shader);

    [JSImport("gl.getShaderParameter", "main.js")]
    internal static partial bool GetShaderParameter(JSObject shader, int pname);

    [JSImport("gl.getShaderInfoLog", "main.js")]
    internal static partial string GetShaderInfoLog(JSObject shader);

    [JSImport("gl.deleteShader", "main.js")]
    internal static partial void DeleteShader(JSObject shader);

    [JSImport("gl.createProgram", "main.js")]
    internal static partial JSObject CreateProgram();

    [JSImport("gl.attachShader", "main.js")]
    internal static partial void AttachShader(JSObject program, JSObject shader);

    [JSImport("gl.linkProgram", "main.js")]
    internal static partial void LinkProgram(JSObject program);

    [JSImport("gl.getProgramParameter", "main.js")]
    internal static partial bool GetProgramParameter(JSObject program, int pname);

    [JSImport("gl.getProgramInfoLog", "main.js")]
    internal static partial string GetProgramInfoLog(JSObject program);

    [JSImport("gl.useProgram", "main.js")]
    internal static partial void UseProgram(JSObject program);

    [JSImport("gl.getAttribLocation", "main.js")]
    internal static partial int GetAttribLocation(JSObject program, string name);

    [JSImport("gl.createBuffer", "main.js")]
    internal static partial JSObject CreateBuffer();

    [JSImport("gl.bindBuffer", "main.js")]
    internal static partial void BindBuffer(int target, JSObject buffer);

    [JSImport("gl.bufferData", "main.js")]
    internal static partial void BufferData(int target, JSObject data, int usage);

    [JSImport("gl.vertexAttribPointer", "main.js")]
    internal static partial void VertexAttribPointer(int index, int size, int type, bool normalized, int stride, int offset);

    [JSImport("gl.enableVertexAttribArray", "main.js")]
    internal static partial void EnableVertexAttribArray(int index);

    [JSImport("gl.clearColor", "main.js")]
    internal static partial void ClearColor(float red, float green, float blue, float alpha);

    [JSImport("gl.clear", "main.js")]
    internal static partial void Clear(int mask);

    [JSImport("gl.drawArrays", "main.js")]
    internal static partial void DrawArrays(int mode, int first, int count);
}
