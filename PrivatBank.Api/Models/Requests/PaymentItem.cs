using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models.Requests
{
    public class PaymentItem
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
