using System.Diagnostics;
using System.Timers;

namespace WebGL.Template;

public sealed class GameController : IDisposable
{
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(1.0 / 60.0);
    private readonly System.Timers.Timer _timer;
    private readonly Stopwatch _stopwatch = new();
    private readonly IGame _game;

    public GameController(IGame game)
    {
        _game = game;
        _timer = new System.Timers.Timer(_interval);
        _timer.Elapsed += Tick;
    }

    public void Start()
    {
        _game.Initialize(new ShaderLoader());
        GameSingleton.Instance = _game;
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

    public void Dispose()
    {
        _timer.Dispose();
    }
}
