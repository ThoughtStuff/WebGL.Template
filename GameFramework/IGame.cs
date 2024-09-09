namespace WebGL.Template.GameFramework;

public interface IGame : IRenderer, IDisposable
{
    /// <summary>
    /// Optional text to display in the FPS overlay.
    /// </summary>
    string? OverlayText { get; }

    /// <summary>
    /// Loads essential assets such as textures and sounds asynchronously.
    /// Called before InitializeScene.
    /// Use for loading smaller lower-fidelity assets for first render.
    /// </summary>
    Task LoadAssetsEssentialAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader);

    /// <summary>
    /// Creates initial resources for the game scene.
    /// </summary>
    void InitializeScene(IShaderLoader shaderLoader);

    /// <summary>
    /// Called after first Update and Render.
    /// Use for loading larger higher-fidelity assets.
    /// </summary>
    Task LoadAssetsExtendedAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader);

    /// <summary>
    /// Updates the game scene based on the elapsed wall-clock time.
    /// </summary>
    /// <param name="deltaTime">The wall-clock time elapsed since the last update.</param>
    void Update(TimeSpan deltaTime);

    /// <summary>
    /// Updates the game scene at a fixed time interval.
    /// Typically used for physics updates.
    /// </summary>
    /// <param name="deltaTime">The fixed time interval for the update.</param>
    void FixedUpdate(TimeSpan deltaTime);

    #region User Input Handling

    /// <summary>
    /// Handles keyboard events such as key presses and releases.
    /// </summary>
    /// <param name="key">The name of the key that was pressed or released e.g. "ArrowUp".</param>
    /// <param name="pressed">Indicates whether the key was pressed (true) or released (false).</param>
    void OnKeyPress(string key, bool pressed);

    /// <summary>
    /// Handles mouse click events.
    /// </summary>
    /// <param name="button">The mouse button that was pressed or released.</param>
    /// <param name="pressed">Indicates whether the button was pressed (true) or released (false).</param>
    /// <param name="position">The normalized x and y coordinates of the mouse pointer.</param>
    void OnMouseClick(int button, bool pressed, Vector2 position);

    /// <summary>
    /// Handles mouse move events.
    /// Coordinates are normalized to the range [0, 1] 
    /// with the origin in the bottom-left.
    /// </summary>
    /// <param name="position">The normalized x and y coordinates of the mouse pointer.</param>
    void OnMouseMove(Vector2 position);

    /// <summary>
    /// Handles touch start event.
    /// Coordinates are normalized to the range [0, 1]
    /// </summary>
    void OnTouchStart(IEnumerable<Vector2> touches);

    /// <summary>
    /// Handles touch move event.
    /// Coordinates are normalized to the range [0, 1]
    /// </summary>
    void OnTouchMove(IEnumerable<Vector2> touches);

    /// <summary>
    /// Handles touch end event.
    /// </summary>
    void OnTouchEnd(IEnumerable<Vector2> touches);

    #endregion
}
