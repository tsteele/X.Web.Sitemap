using System.IO;

namespace X.Web.Sitemap
{
    public interface IFileSystemWrapper
    {
        bool DirectoryExists(string pathToDirectory);
        FileInfo WriteFile(string xmlString, DirectoryInfo targetDirectory, string targetFileName);
    }
}
