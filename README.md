# .NET WebGL Template

This template is a starting point for creating .NET projects that target WebAssembly and leverage WebGL.

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
