using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Extensions.FileProviders;

namespace X.Web.Sitemap
{
    public class SerializedXmlSaver<T> : ISerializedXmlSaver<T>
    {
        private readonly IFileSystemWrapper _fileSystemWrapper;

        public SerializedXmlSaver(IFileSystemWrapper fileSystemWrapper)
        {
            _fileSystemWrapper = fileSystemWrapper;
        }

        public IFileInfo SerializeAndSave(T objectToSerialize, DirectoryInfo targetDirectory, string targetFileName)
        {
            ValidateArgumentNotNull(objectToSerialize);

            var xmlSerializer = new XmlSerializer(typeof(T));
            
            using (var textWriter = new StringWriterUtf8())
            {
                xmlSerializer.Serialize(textWriter, objectToSerialize);
                var xmlString = textWriter.ToString();
                return _fileSystemWrapper.WriteFile(xmlString, targetDirectory, targetFileName);
            }
        }

        private static void ValidateArgumentNotNull(T objectToSerialize)
        {
            if (objectToSerialize == null)
            {
                throw new ArgumentNullException(nameof(objectToSerialize));
            }
        }
    }
}