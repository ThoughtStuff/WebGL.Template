namespace WebGL.Template;

public static class GameEngineSingleton
{
    /// <summary>
    /// Set this instance and the interop will invoke the methods on this instance.
    /// </summary>
    public static IGameEngine? Instance { get; set; }
}
