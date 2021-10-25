using System;

namespace Crypton.Model.BitBay.Responses
{
    public class BitBayTransaction
    {
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal Value { get; set; }
        public string Market { get; set; }
        public string ExchangeType { get; set; }
    }
}
