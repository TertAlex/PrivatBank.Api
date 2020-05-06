using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models.Response
{
    public class ResponseInfo<T>
    {
        [XmlElement(ElementName = "statements")]
        public T Response { get; set; }
    }
}
