using System.Diagnostics;
using System.Timers;

namespace WebGL.Template;

public sealed class GameController : IDisposable, IRenderer
{
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(1.0 / 60.0);
    private readonly System.Timers.Timer _timer;
    private readonly Stopwatch _stopwatch = new();
    private readonly IGame _game;
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
        _timer.Start();
        _stopwatch.Start();
    }

    private void Tick(object? sender, ElapsedEventArgs e)
    {
        // Call Update with elapsed wall-clock time
        var deltaTime = _stopwatch.Elapsed;
        _stopwatch.Restart();
        _game.Update(deltaTime);
        // Call FixedUpdate with fixed time interval
        _game.FixedUpdate(_interval);
    }

    public void Render()
    {
        // Wrap the Game's Render method to catch & report exceptions 
        // so that the render loop is not killed
        try
        {
            _game.Render();
        }
        catch (Exception ex)
        {
            if (_lastRenderError != ex.Message)
            {
                _lastRenderError = ex.Message;
                Console.Error.WriteLine(ex);
            }
        }
    }

    public void Dispose()
    {
        _timer.Dispose();
    }
}
