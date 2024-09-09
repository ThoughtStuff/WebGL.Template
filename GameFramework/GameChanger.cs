namespace WebGL.Template.GameFramework;

/// <summary>
/// A game that can switch between multiple games using the PageUp and PageDown keys.
/// </summary>
/// <remarks>
/// The provided games must properly clean up their GL resources when <see cref="IDisposable.Dispose"/> is called.
/// </remarks>
public sealed class GameChanger : IGame
{
    private readonly IList<IGame> _games;
    private int _currentIndex;
    private IGame ActiveGame => _games[_currentIndex];
    private IShaderLoader? _shaderLoader;
    private ITextureLoader? _textureLoader;
    private bool _canSwitch;

    public GameChanger(params IGame[] games)
    {
        if (games is null || !games.Any())
            throw new ArgumentException("At least one game must be provided.", nameof(games));

        _games = games;
        _currentIndex = 0;
        _canSwitch = true;
    }

    public async Task LoadAssetsExtendedAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader)
    {
        await ActiveGame.LoadAssetsExtendedAsync(shaderLoader, textureLoader);
        // Save the loaders for later use
        // Do this after last step of initialization to prevent switching during initialization process
        _shaderLoader = shaderLoader;
        _textureLoader = textureLoader;
    }

    public void OnKeyPress(string key, bool pressed)
    {
        if (pressed)
        {
            if (key == "PageDown")
            {
                SwitchGame(1);
            }
            else if (key == "PageUp")
            {
                SwitchGame(-1);
            }
        }
        else
        {
            ActiveGame.OnKeyPress(key, pressed);
        }
    }

    private async void SwitchGame(int direction)
    {
        if (!_canSwitch || _shaderLoader is null || _textureLoader is null)
            return;
        _canSwitch = false;

        ActiveGame.Dispose();

        _currentIndex = (_currentIndex + direction + _games.Count) % _games.Count;

        await ActiveGame.LoadAssetsEssentialAsync(_shaderLoader, _textureLoader);
        ActiveGame.InitializeScene(_shaderLoader);
        await Task.Delay(100);
        await ActiveGame.LoadAssetsExtendedAsync(_shaderLoader, _textureLoader);

        _canSwitch = true;
    }

    #region Active Game Passthrough

    public string? OverlayText => ActiveGame.OverlayText;
    public Task LoadAssetsEssentialAsync(IShaderLoader shaderLoader, ITextureLoader textureLoader) => ActiveGame.LoadAssetsEssentialAsync(shaderLoader, textureLoader);
    public void InitializeScene(IShaderLoader shaderLoader) => ActiveGame.InitializeScene(shaderLoader);
    public void Dispose() => ActiveGame.Dispose();
    public void Update(TimeSpan deltaTime) => ActiveGame.Update(deltaTime);
    public void FixedUpdate(TimeSpan deltaTime) => ActiveGame.FixedUpdate(deltaTime);
    public void Render() => ActiveGame.Render();
    public void OnMouseClick(int button, bool pressed, Vector2 position) => ActiveGame.OnMouseClick(button, pressed, position);
    public void OnMouseMove(Vector2 position) => ActiveGame.OnMouseMove(position);
    public void OnTouchStart(IEnumerable<Vector2> touches) => ActiveGame.OnTouchStart(touches);
    public void OnTouchMove(IEnumerable<Vector2> touches) => ActiveGame.OnTouchMove(touches);
    public void OnTouchEnd(IEnumerable<Vector2> touches) => ActiveGame.OnTouchEnd(touches);

    #endregion
}
