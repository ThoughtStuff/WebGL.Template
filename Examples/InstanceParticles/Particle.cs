namespace WebGL.Template.Examples.InstanceParticles;

public sealed class Particle(Vector2 position,
                             Vector2 velocity,
                             Vector2 scale,
                             float rotation,
                             int[] frameIndices,
                             int initialFrame,
                             double fps)
{
    private const double LifeSpanSeconds = 5;
    private readonly TimeSpan FrameDuration = TimeSpan.FromSeconds(1.0 / fps);

    public Vector2 Position { get; set; } = position;
    public Vector2 Velocity { get; set; } = velocity;
    public Vector2 Scale { get; set; } = scale;
    public float Rotation { get; set; } = rotation;
    public TimeSpan Lifetime { get; private set; } = TimeSpan.FromSeconds(LifeSpanSeconds);
    public bool Dead { get; private set; } = false;
    public int FrameIndex { get; private set; } = initialFrame;
    private readonly int[] _frameIndices = frameIndices;

    public void Update(TimeSpan deltaTime)
    {
        if (Dead)
            return;

        // Update position based on velocity
        Position += Velocity * (float)deltaTime.TotalSeconds;

        // Decrease the lifetime by the elapsed time
        Lifetime -= deltaTime;

        // Update the particle's sprite index based on time
        var elapsedSeconds = LifeSpanSeconds - Lifetime.TotalSeconds;
        int totalFramesElapsed = (int)(elapsedSeconds / FrameDuration.TotalSeconds);
        FrameIndex = _frameIndices[totalFramesElapsed % _frameIndices.Length];

        // Check if the particle's lifetime has expired
        if (Lifetime <= TimeSpan.Zero)
        {
            // Mark the particle as dead and reset its values
            Dead = true;
            Reset();
        }
    }

    private void Reset()
    {
        Position = default;
        Velocity = default;
        Scale = Vector2.Zero;
        Lifetime = TimeSpan.Zero;
    }
}
