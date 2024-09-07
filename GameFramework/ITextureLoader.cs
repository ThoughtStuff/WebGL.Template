using System.Runtime.InteropServices.JavaScript;

namespace WebGL.Template.GameFramework;

public interface ITextureLoader
{
    Task<JSObject> LoadTexture(string url,
                               bool mipMapping = true,
                               bool nearestNeighborMagnification = false);
}
