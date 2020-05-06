using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models.Response
{
    public class ResponseData<T>
    {   
        [XmlElement(ElementName = "oper")]
        public string Oper { get; set; }

        [XmlElement(ElementName = "info")]
        public ResponseInfo<T> Info { get; set; }
    }
}
