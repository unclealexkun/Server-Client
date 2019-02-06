using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SerializeDLL
{
    public class XmlSerialize: ISerialize
    {
        private
        XmlSerializer XMLd = new XmlSerializer(typeof(Input));
        XmlSerializer XMLs = new XmlSerializer(typeof(Output));

        public Input DeSerialize(string str)
        {
            var xmlReader = XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(str)));
            return XMLd.Deserialize(xmlReader) as Input;
        }

        public string Serialize(Output data)
        {
            StringWriter strWriter = new StringWriter();

            XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;

            XmlSerializerNamespaces xmlSerializerNamespace = new XmlSerializerNamespaces();
            xmlSerializerNamespace.Add("","");

            var xmlWriter = XmlWriter.Create(strWriter, settings);
            XMLs.Serialize(xmlWriter, data, xmlSerializerNamespace);

            return strWriter.ToString();
        }
    }
}
