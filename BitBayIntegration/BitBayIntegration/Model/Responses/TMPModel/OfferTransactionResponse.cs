using System.Collections.Generic;

namespace Crypton.Model.BitBay.Responses.TMPModel
{
    public class OfferTransactionResponse
    {
        public string offerId { get; set; }
        public List<transactions> transactions { get; set; }
    }

    public class transactions
    {
        public string amount { get; set; }
        public string rate { get; set; }
    }
}
