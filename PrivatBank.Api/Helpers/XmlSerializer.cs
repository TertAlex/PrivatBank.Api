using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Helpers
{
    public static class XmlSerializer
    {
        public static string Serialize<T>(T data)
        {
            string serializeXml;

            using (var stringWriter = new StringWriter())
            {
                var xmlserializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, data, ns);
                    serializeXml = stringWriter.ToString();
                    writer.Close();
                }
            }

            return serializeXml;
        }

        public static T Deserialize<T>(string xml)
        {
            using (TextReader stringReader = new StringReader(xml))
            {
                var ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (var reader = XmlReader.Create(stringReader))
                {
                    return (T) ser.Deserialize(reader);
                }
            }
        }
    }
}
