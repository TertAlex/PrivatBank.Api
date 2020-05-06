using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models
{
    public class Statements
    {
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }

        [XmlAttribute(AttributeName = "credit")]
        public string Credit { get; set; }

        [XmlAttribute(AttributeName = "debet")]
        public string Debet { get; set; }

        [XmlElement(ElementName = "statement")]
        public List<Statement> StatementItem { get; set; }
    }
}
