using System.Runtime.InteropServices.JavaScript;
using WebGL.Template.Interop;

namespace WebGL.Template.GameFramework;

class TextureLoader : ITextureLoader
{
    /// <inheritdoc/>
    public async Task<JSObject> LoadTexture(string url,
                                            bool mipMapping,
                                            bool nearestNeighborMagnification)
    {
        // Load image using JS interop
        var image = await Utility.LoadImageFromUrl(url);
        var texture = GL.CreateTexture();
        GL.BindTexture(GL.TEXTURE_2D, texture);
        GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MIN_FILTER,
            mipMapping ? GL.LINEAR_MIPMAP_LINEAR : GL.LINEAR);
        GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MAG_FILTER,
            nearestNeighborMagnification ? GL.NEAREST : GL.LINEAR);
        GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_S, GL.CLAMP_TO_EDGE);
        GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_T, GL.CLAMP_TO_EDGE);
        GL.TexImage2D(GL.TEXTURE_2D, 0, GL.RGBA, GL.RGBA, GL.UNSIGNED_BYTE, image);
        if (mipMapping)
        {
            GL.GenerateMipmap(GL.TEXTURE_2D);
        }
        return texture;
    }
}
