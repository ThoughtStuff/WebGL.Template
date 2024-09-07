using WebGL.Template;
using WebGL.Template.GameFramework;

// Print information about the GL context to demonstrate that WebGL is working
var version = GL.GetParameterString(GL.VERSION);
Console.WriteLine("GL Version: " + version);
var vendor = GL.GetParameterString(GL.VENDOR);
Console.WriteLine("GL Vendor: " + vendor);
var renderer = GL.GetParameterString(GL.RENDERER);
Console.WriteLine("GL Renderer: " + renderer);
var glslVersion = GL.GetParameterString(GL.SHADING_LANGUAGE_VERSION);
Console.WriteLine("GLSL Version: " + glslVersion);

// Bootstrap our Game which handles input, updates, and rendering
var game = new ExampleGame();
using var gameController = new GameController(game);
await gameController.Start();

// Prevent the main method from exiting so that the game loop (Timer) can continue
while (true)
{
    await Task.Delay(10_000);
}
