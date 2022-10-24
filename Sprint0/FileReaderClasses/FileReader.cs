using Microsoft.Xna.Framework;
using System.Xml;
using System.IO;

namespace sprint0.FileReaderClasses
{
    public abstract class FileReader : IFileReader
    {
        private string fileData = "";

        private XmlDocument xmlDocument;

        public bool LoadFile(string filePath)
        {
            var reader = new StreamReader(TitleContainer.OpenStream(filePath));
            fileData = reader.ReadToEnd();

            xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(fileData);

            ParseXml();

            return false;
        }

        public void SetXmlDocument(XmlDocument xmlDocument)
        {
            this.xmlDocument = xmlDocument;
        }

        public XmlDocument GetXmlDocument()
        {
            return xmlDocument;
        }

        public abstract void ParseXml();
    }
}
