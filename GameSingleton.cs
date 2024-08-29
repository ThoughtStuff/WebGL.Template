namespace WebGL.Template;

public static class GameSingleton
{
    /// <summary>
    /// Set this instance and the interop will invoke the methods on this instance.
    /// </summary>
    public static IGame? Instance { get; set; }
}
