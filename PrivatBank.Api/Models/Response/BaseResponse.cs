using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models.Response
{
    [XmlRoot("response")]
    public class BaseResponse<T>
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlElement(ElementName = "merchant")]
        public Merchant Merchant { get; set; }

        [XmlElement(ElementName = "data")]
        public ResponseData<T> Data { get; set; }
    }
}
