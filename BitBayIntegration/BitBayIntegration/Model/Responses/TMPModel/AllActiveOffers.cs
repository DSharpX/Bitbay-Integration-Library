using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypton.Model.BitBay.Responses.TMPModel
{
    public class AllActiveOffers
    {
        public string status { get; set; }
        public List<ActiveOffers> items { get; set; }
    }

    public class ActiveOffers
    {
        public string market { get; set; }
        public string offerType { get; set; }
        public string id { get; set; }
        public string currentAmount { get; set; }
        public string lockedAmount { get; set; }
        public string rate { get; set; }
        public string startAmount { get; set; }
        public string time { get; set; }
        public bool postOnly { get; set; }
        public bool hidden { get; set; }
        public string mode { get; set; }
        public string receivedAmount { get; set; }
        public string firstBalanceId { get; set; }
        public string secondBalanceId { get; set; }
    }
}
