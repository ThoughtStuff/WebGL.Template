using System.Reflection;

namespace WebGL.Template;

public class ResourceLoading
{
    public static string LoadEmbeddedResourceText(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var @namespace = typeof(ResourceLoading).Namespace;
        using var stream = assembly.GetManifestResourceStream($"{@namespace}.{resourceName}") ??
                           throw new InvalidOperationException($"Resource {resourceName} not found.");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
