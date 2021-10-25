namespace Crypton.Model.BitBay.Responses.TMPModel
{
    public class GetConfigResponse
    {
        public string status { get; set; }
        public Config config { get; set; }
    }
    public class Config
    {
        public OfferType buy { get; set; }
        public OfferType sell { get; set; }
        public MinValue first { get; set; }
        public MinValue second { get; set; }
    }
    public class OfferType
    {
        public Commisions commissions { get; set; }
    }
    public class Commisions
    {
        public string maker { get; set; }
        public string taker { get; set; }
    }
    public class MinValue
    {
        public string balanceId { get; set; }
        public string minValue { get; set; }
    }
}
