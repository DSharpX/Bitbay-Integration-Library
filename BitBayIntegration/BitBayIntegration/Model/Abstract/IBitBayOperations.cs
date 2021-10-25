using Crypton.Model.BitBay.Requests;
using Crypton.Model.BitBay.Responses.TMPModel;
using System.Threading.Tasks;

namespace BitBayIntegration.Model.Abstract
{
    interface IBitBayOperations
    {
        Task<OfferTransactionResponse> CreateOffer(CreateOfferModel offerModel, string marketCode, decimal rate);
        Task<AllActiveOffers> GetActiveOffers(string marketCode);
        Task DeleteOffer(string marketCode, string id, string offerType, string rate);
        Task<GetConfigResponse> GetConfig(string marketCode);
        Task<OrderBookResponse> GetOrderBook(string marketCode, string count = "");
        Task<WalletBalanceResponse> GetWalletsBalance();
        Task<decimal> GetWalletBalance(string name);
    }
}
