using System.IO;
using Microsoft.Extensions.FileProviders;

namespace X.Web.Sitemap.Tests {
    public class TestFileSystemWrapper : IFileSystemWrapper
	{
		public bool DirectoryExists(string pathToDirectory)
		{
			return true;
		}

		public IFileInfo WriteFile(string xmlString, DirectoryInfo targetDirectory, string targetFileName)
		{
            var provider = new PhysicalFileProvider(targetDirectory.FullName);
            var file = provider.GetFileInfo(targetFileName);
			return file;
		}		
	}
}
