using System.IO;
using Microsoft.Extensions.FileProviders;

namespace X.Web.Sitemap
{
    public interface IFileSystemWrapper
    {
        bool DirectoryExists(string pathToDirectory);
        IFileInfo WriteFile(string xmlString, DirectoryInfo targetDirectory, string targetFileName);
    }
}
