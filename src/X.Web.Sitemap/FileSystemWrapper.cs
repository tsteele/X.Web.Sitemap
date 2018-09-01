using System.IO;
using Microsoft.Extensions.FileProviders;

namespace X.Web.Sitemap
{
    public class FileSystemWrapper : IFileSystemWrapper
    {
        public bool DirectoryExists(string pathToDirectory)
        {
            return new DirectoryInfo(pathToDirectory).Exists;
        }

        public IFileInfo WriteFile(string xmlString, DirectoryInfo targetDirectory, string targetFileName)
        {
            if (!targetDirectory.Exists)
            {
                targetDirectory.Create();
            }

            var fullPath = Path.Combine(targetDirectory.FullName, targetFileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            var provider = new PhysicalFileProvider(targetDirectory.FullName);
            var fileInfo = provider.GetFileInfo(targetFileName);
            if (fileInfo.Exists) File.Delete(fileInfo.PhysicalPath);

            File.WriteAllText(fullPath, xmlString);

            return provider.GetFileInfo(targetFileName);
        }
    }
}