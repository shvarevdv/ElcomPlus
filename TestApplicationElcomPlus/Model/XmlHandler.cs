using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace TestApplicationElcomPlus.Model
{
    public class XmlHandler
    {
        private string filePath;
        private ValuesFromFile valueXml;


        public XmlHandler(string filePath)
        {
            this.filePath = filePath;
            valueXml = new ValuesFromFile();
        }

        public ValuesFromFile Handle()
        {
            XmlFileRead();
            return valueXml;
        }

        private void XmlFileRead()
        {
            XDocument xdoc = XDocument.Load(filePath);
            valueXml.Values = xdoc.Descendants("Value")
                             .Select(elem => elem.Value).ToList();
                        
        }
    }
}
