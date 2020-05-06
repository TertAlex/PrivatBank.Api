using System;
using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models
{
    [Serializable]
    public class Merchant
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "signature")]
        public string Signature { get; set; }
    }
}
