using System.Diagnostics;
using System.Timers;

namespace WebGL.Template;

public sealed class GameController : IDisposable, IRenderer, IOverlayHandler
{
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(1.0 / 60.0);
    private readonly System.Timers.Timer _timer;
    private readonly Stopwatch _stopwatch = new();
    private readonly IGame _game;
    private readonly FpsCounter _fpsCounter = new();
    private string _lastRenderError = string.Empty;

    public GameController(IGame game)
    {
        _game = game;
        _timer = new System.Timers.Timer(_interval);
        _timer.Elapsed += Tick;
    }

    public void Start()
    {
        _game.Initialize(new ShaderLoader());
        Singletons.GameInstance = _game;
        Singletons.RendererInstance = this;
        Singletons.OverlayHandlerInstance = this;
        _timer.Start();
        _stopwatch.Start();
        _fpsCounter.Start();
    }

    private void Tick(object? sender, ElapsedEventArgs e)
    {
        // Call Update with elapsed wall-clock time
        var deltaTime = _stopwatch.Elapsed;
        _stopwatch.Restart();
        _game.Update(deltaTime);

        // Call FixedUpdate with fixed time interval
        _game.FixedUpdate(_interval);

        // Update Overlay GUI
        Overlay.SetFPS($"{_fpsCounter.Fps:F2} Hz");
        Overlay.SetErrorMessage(_lastRenderError);
    }

    public void Render()
    {
        // Wrap the Game's Render method to catch & report exceptions
        // so that the render loop is not killed
        try
        {
            _fpsCounter.Update();
            _game.Render();
        }
        catch (Exception ex)
        {
            if (_lastRenderError != ex.ToString())
            {
                _lastRenderError = ex.ToString();
                Console.Error.WriteLine(ex);
            }
        }
    }

    public void ClearErrorMessage()
    {
        _lastRenderError = string.Empty;
    }

    public void Dispose()
    {
        _timer.Dispose();
    }
}
