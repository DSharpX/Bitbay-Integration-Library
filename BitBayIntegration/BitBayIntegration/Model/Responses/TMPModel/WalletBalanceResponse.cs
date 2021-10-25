using System.Collections.Generic;

namespace Crypton.Model.BitBay.Responses.TMPModel
{
    public class WalletBalanceResponse
    {
        public string status { get; set; }
        public List<Wallet> balances { get; set; }
    }

    public class Wallet
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public decimal availableFunds { get; set; }
        public decimal totalFunds { get; set; }
        public decimal lockedFunds { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public string balanceEngine { get; set; }
    }
}
