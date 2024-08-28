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

    public const int VERTEX_SHADER = 0x8B31;
    public const int FRAGMENT_SHADER = 0x8B30;
    public const int COMPILE_STATUS = 0x8B81;
    public const int LINK_STATUS = 0x8B82;
    public const int ARRAY_BUFFER = 0x8892;
    public const int STATIC_DRAW = 0x88E4;
    public const int FLOAT = 0x1406;

    public const int POINTS = 0x0000;
    public const int LINES = 0x0001;
    public const int LINE_LOOP = 0x0002;
    public const int LINE_STRIP = 0x0003;
    public const int TRIANGLES = 0x0004;

    public const int COLOR_BUFFER_BIT = 0x00004000;
}
