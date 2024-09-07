# .NET WebGL Template

```
dotnet new webgl
```

This template is a starting point for creating .NET projects that target WebAssembly and leverage WebGL.

### Game Framework

This includes a very basic `GameFramework` to help you get started.
You only need to implement `IGame` and pass your Game instance to the `GameController` in `Program.cs`.
See [`ExampleGame.cs`](./ExampleGame.cs) for a simple example.
See the [Examples](./Examples) folder for more examples.

That said, you are not required to use the `GameFramework`. You can delete the `GameFramework` folder and implement your own rendering and update logic.

The `IGame` interface provides some "lifecycle" methods for you to implement for initialization, input, updates and rendering.
These methods are called by the `GameController` at the appropriate times.
See [IGame.cs](./GameFramework/IGame.cs) for documentation.


Invoking WebGL functions is straightforward via the global static `GL` class.

```cs
GL.ClearColor(0.39f, 0.58f, 0.93f, 1.0f);
GL.Clear(GL.COLOR_BUFFER_BIT);
```

---

### Interop

The GL context is effectively exported by JS as follows:

```js
const canvas = document.getElementById("canvas");
const gl = canvas.getContext("webgl");
setModuleImports("main.js", { gl });
```

And imported in C# as in this example:

```cs
static partial class GL
{
    [JSImport("gl.clearColor", "main.js")]
    internal static partial void ClearColor(float red, float green, float blue, float alpha);
}
```

So this approach is limited to one Canvas context.
