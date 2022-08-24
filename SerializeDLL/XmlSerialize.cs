using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SerializeLibrary
{
  /// <summary>
  /// Xml сериализация.
  /// </summary>
  public class XmlSerialize<T>: ISerialize<T>
  {
		#region Поля и свойства

    /// <summary>
    /// Xml сериализатор.
    /// </summary>
		private XmlSerializer serializer = new XmlSerializer(typeof(T));

    #endregion

    #region ISerialize

    public T DeSerialize(string str)
    {
      using (var xmlReader = XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(str))))
        return (T)serializer.Deserialize(xmlReader);
    }

    public string Serialize(T data)
    {
      using (var stringWriter = new StringWriter())
      {
        var settings = new XmlWriterSettings();
        settings.OmitXmlDeclaration = true;
        settings.NewLineOnAttributes = true;

        var xmlSerializerNamespace = new XmlSerializerNamespaces();
        xmlSerializerNamespace.Add(string.Empty, string.Empty);

        using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
				{
          serializer.Serialize(xmlWriter, data, xmlSerializerNamespace);
          return stringWriter.ToString();
        }
      }
    }

		#endregion
	}
}
