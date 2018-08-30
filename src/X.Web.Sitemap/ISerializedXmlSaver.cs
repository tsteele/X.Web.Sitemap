using System.IO;

namespace X.Web.Sitemap
{
    public interface ISerializedXmlSaver<in T>
    {
        FileInfo SerializeAndSave(T objectToSerialize, DirectoryInfo targetDirectory, string targetFileName);
    }
}