using System.Reflection;

namespace WebGL.Template;

public class ResourceLoading
{
    public static string LoadEmbeddedResourceText(string resourcePath)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var @namespace = typeof(ResourceLoading).Namespace;
        resourcePath = resourcePath.Replace("/", ".")
                                   .Replace("\\", ".");
        var resourceName = $"{@namespace}.{resourcePath}";
        using var stream = assembly.GetManifestResourceStream(resourceName) ??
                           throw new InvalidOperationException($"Resource '{resourceName}' not found.");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
