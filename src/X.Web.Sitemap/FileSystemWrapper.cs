using System;
using System.IO;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.FileProviders;

namespace X.Web.Sitemap;

[PublicAPI]
public interface IFileSystemWrapper
{
    /// <summary>
    /// Writes the specified XML to the specified path.
    /// </summary>
    /// <param name="xml"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    IFileInfo WriteFile(string xml, string path);
            
    /// <summary>
    /// Writes the specified XML to the specified path asynchronously.
    /// </summary>
    /// <param name="xml"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    Task<IFileInfo> WriteFileAsync(string xml, string path);
}

public class FileSystemWrapper : IFileSystemWrapper
{

    public IFileInfo WriteFile(string xml, string path)
    {
        var directory = Path.GetDirectoryName(path);

        EnsureDirectoryCreated(directory);

        using (var file = new FileStream(path, FileMode.Create))
        using (var writer = new StreamWriter(file))
        {
            writer.Write(xml);
        }

        var targetDirectory = new DirectoryInfo(directory);
        var provider = new PhysicalFileProvider(targetDirectory.FullName);
        var fileInfo = provider.GetFileInfo(Path.GetFileName(path));

        return fileInfo;
    }

    public async Task<IFileInfo> WriteFileAsync(string xml, string path)
    {
        var directory = Path.GetDirectoryName(path);

        EnsureDirectoryCreated(directory);

        using (var file = new FileStream(path, FileMode.Create))
        using (var writer = new StreamWriter(file))
        {
            await writer.WriteAsync(xml);
        }
       
        var targetDirectory = new DirectoryInfo(directory);
        var provider = new PhysicalFileProvider(targetDirectory.FullName);
        var fileInfo = provider.GetFileInfo(Path.GetFileName(path));

        return fileInfo;
    }

    public static void EnsureDirectoryCreated(string? directory)
    {
        if (string.IsNullOrEmpty(directory))
        {
            throw new ArgumentException(nameof(directory));
        }

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }


    public bool DirectoryExists(string pathToDirectory)
    {
        return new DirectoryInfo(pathToDirectory).Exists;
    }

}
