using System.IO;
using Microsoft.Extensions.FileProviders;

namespace X.Web.Sitemap
{
    public interface ISerializedXmlSaver<in T>
    {
        IFileInfo SerializeAndSave(T objectToSerialize, DirectoryInfo targetDirectory, string targetFileName);
    }
}