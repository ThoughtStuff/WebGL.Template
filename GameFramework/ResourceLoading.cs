using System.Reflection;

namespace WebGL.Template.GameFramework;

public class ResourceLoading
{
    public static string LoadEmbeddedResourceText(string resourcePath)
    {
        var @namespace = typeof(ResourceLoading).Namespace
                         ?? throw new InvalidOperationException("Namespace not found for resource loading.");
        // Get parent namespace because Shaders folder is in top of project
        @namespace = @namespace.Replace(".GameFramework", "");
        resourcePath = resourcePath.Replace("/", ".")
                                   .Replace("\\", ".");
        var resourceName = $"{@namespace}.{resourcePath}";
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName) ??
                           throw new InvalidOperationException($"Resource '{resourceName}' not found.");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
