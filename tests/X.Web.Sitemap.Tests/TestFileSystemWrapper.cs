
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;

using System.IO;

namespace X.Web.Sitemap.Tests;

public class TestFileSystemWrapper : IFileSystemWrapper
{
	public IFileInfo WriteFile(string xml, string path)
	{
        var directory = Path.GetDirectoryName(path);

		var fileInfo = new PhysicalFileInfo(new FileInfo(path));

        return fileInfo; 
    }

	public Task<IFileInfo> WriteFileAsync(string xml, string path)
	{
		return Task.FromResult(WriteFile(xml, path));
	}
}