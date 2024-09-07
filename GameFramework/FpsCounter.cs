using System.Diagnostics;

namespace WebGL.Template.GameFramework;

public sealed class FpsCounter
{
    private readonly Stopwatch _stopwatch = new();
    private int _frameCount;
    private TimeSpan _lastTime;
    private float _fps;

    public float Fps => _fps;

    public void Start()
    {
        if (!_stopwatch.IsRunning)
        {
            _stopwatch.Start();
            _lastTime = _stopwatch.Elapsed;
        }
    }

    public void Update()
    {
        if (!_stopwatch.IsRunning)
        {
            Start();
        }

        _frameCount++;

        var currentTime = _stopwatch.Elapsed;
        var elapsed = currentTime - _lastTime;

        if (elapsed.TotalSeconds >= 1.0)
        {
            _fps = _frameCount / (float)elapsed.TotalSeconds;
            _frameCount = 0;
            _lastTime = currentTime;
        }
    }
}
