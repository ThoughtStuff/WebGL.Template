# .NET WebGL Template

```
dotnet new webgl
```

This template is a starting point for creating .NET projects that target WebAssembly and leverage WebGL.

Check out `Program.cs` for how easy it is to invoke WebGL functions from C#.
See `RenderLoop.cs` for the Render method that is called every frame.

```cs
GL.ClearColor(0.39f, 0.58f, 0.93f, 1.0f);
GL.Clear(GL.COLOR_BUFFER_BIT);
```

---

The GL context is effectively exported by JS as follows:

```js
const canvas = document.getElementById("canvas");
const gl = canvas.getContext("webgl");
setModuleImports("main.js", { gl });
```

And imported in C# as in this example:

```cs
public static partial class GL
{
    [JSImport("gl.clearColor", "main.js")]
    internal static partial void ClearColor(float red, float green, float blue, float alpha);
}
```

So this approach is limited to one Canvas context.
