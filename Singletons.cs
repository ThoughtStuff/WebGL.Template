namespace WebGL.Template;

public static class Singletons
{
    /// <summary>
    /// Set this instance and the interop will invoke the methods on this instance.
    /// </summary>
    public static IGame? GameInstance { get; set; }

    /// <summary>
    /// Set this instance and the interop will invoke Render() on this instance.
    /// </summary>
    public static IRenderer? RendererInstance { get; set; }

    /// <summary>
    /// Set this instance and the interop will invoke the methods on this instance.
    /// </summary>
    public static IOverlayHandler? OverlayHandlerInstance { get; set; }
}
