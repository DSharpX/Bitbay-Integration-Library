using System;

namespace Crypton.Model.BitBay.Responses
{
    public class BitBayWallet
    {
        public Guid WalletId { get; set; }
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public decimal AvailableFunds { get; set; }
        public decimal TotalFunds { get; set; }
        public decimal LockedFunds { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public string BalanceEngine { get; set; }
        public decimal PlnValue { get; set; }
    }
}
