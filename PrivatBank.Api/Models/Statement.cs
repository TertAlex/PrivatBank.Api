using System.Xml.Serialization;

namespace Sentinelab.PrivatBank.Api.Models
{
    public class Statement
    {
        [XmlAttribute(AttributeName = "card")]
        public string Card { get; set; }

        [XmlAttribute(AttributeName = "appcode")]
        public string AppCode { get; set; }

        [XmlAttribute(AttributeName = "trandate")]
        public string TranDate { get; set; }

        [XmlAttribute(AttributeName = "trantime")]
        public string TranTime { get; set; }

        [XmlAttribute(AttributeName = "amount")]
        public string Amount { get; set; }

        [XmlAttribute(AttributeName = "cardamount")]
        public string CardAmount { get; set; }

        [XmlAttribute(AttributeName = "rest")]
        public string Rest { get; set; }

        [XmlAttribute(AttributeName = "terminal")]
        public string Terminal { get; set; }

        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }
    }
}
