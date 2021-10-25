namespace Crypton.Model.BitBay.Requests
{
    public class CreateOfferModel
    {
        public string amount { get; set; }
        public string rate { get; set; }
        public string offerType { get; set; }
        public string mode { get; set; }
        public bool postOnly { get; set; }
        public bool hidden { get; set; }
        public bool fillOrKill { get; set; }
        public string price { get; set; }
        public bool immediateOrCancel { get; set; }
        public string firstBalanceId { get; set; }
        public string secondBalanceId { get; set; }
    }
}
