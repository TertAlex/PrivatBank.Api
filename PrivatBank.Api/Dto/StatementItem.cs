using System;

namespace Sentinelab.PrivatBank.Api.Dto
{
    public class StatementItem
    {
        public string Card { get; set; }
        public string AppCode { get; set; }

        public DateTime Time { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

        public double Rest { get; set; }
        public string Terminal { get; set; }
        public string Description { get; set; }
    }
}
