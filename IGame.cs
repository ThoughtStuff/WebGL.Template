namespace WebGL.Template;

public interface IGame
{
    /// <summary>
    /// Creates initial resources for the game scene.
    /// </summary>
    void Initialize(IShaderLoader shaderLoader);

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
    void OnMouseClick(int button, bool pressed);

    /// <summary>
    /// Handles mouse move events.
    /// </summary>
    /// <param name="x">The normalized x-coordinate of the mouse pointer.</param>
    /// <param name="y">The normalized y-coordinate of the mouse pointer.</param>
    void OnMouseMove(float x, float y);

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

    /// <summary>
    /// Renders the current game scene.
    /// </summary>
    void Render();
}
