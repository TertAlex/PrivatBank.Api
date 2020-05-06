using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models.Requests
{
    [XmlRoot("request")]
    public class BaseRequest
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlElement(ElementName = "merchant")]
        public Merchant Merchant { get; set; }

        [XmlElement(ElementName = "data")]
        public RequestData Data { get; set; }
    }
}
