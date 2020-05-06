using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models.Requests
{
    public class Payment
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "prop")]
        public List<PaymentItem> PaymentItems { get; set; }
    }
}
