using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models.Requests
{
    public class RequestData
    {
        [XmlElement(ElementName = "oper")]
        public string Oper { get; set; }

        [XmlElement(ElementName = "wait")]
        public short Wait { get; set; }

        [XmlElement(ElementName = "test")]
        public short Test { get; set; }

        [XmlElement(ElementName = "payment")]
        public Payment Payment { get; set; }
    }
}
