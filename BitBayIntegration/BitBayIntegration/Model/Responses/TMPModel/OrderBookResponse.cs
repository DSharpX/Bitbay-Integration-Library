using System.Collections.Generic;

namespace Crypton.Model.BitBay.Responses.TMPModel
{
    public class OrderBookResponse
    {
        public string status { get; set; }
        public List<Offers> sell { get; set; }
        public List<Offers> buy { get; set; }
        public string timestamp { get; set; }
        public string seqNo { get; set; }
    }

    public class Offers
    {
        public string ra { get; set; }
        public string ca { get; set; }
        public string sa { get; set; }
        public string pa { get; set; }
        public int co { get; set; }
    }
}
