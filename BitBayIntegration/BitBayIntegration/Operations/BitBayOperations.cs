using BitBayIntegration.Logs;
using BitBayIntegration.Model.Abstract;
using BitBayIntegration.Resources;
using Crypton.Model.BitBay.Requests;
using Crypton.Model.BitBay.Responses.TMPModel;
using System.Linq;
using System.Threading.Tasks;

namespace BitBayIntegration.Operations
{
    public class BitBayOperations : BitbayBase, IBitBayOperations
    {
        /// <summary>
        /// Creates an offer on bitbay
        /// </summary>
        /// <param name="model">Properties of the offer</param>
        public async Task<OfferTransactionResponse> CreateOffer(CreateOfferModel model, string marketCode, decimal rate)
        {
            Logger.Trace($"Creating BitBayOffer [{model.offerType}]");

            return await PostMethodAsync<CreateOfferModel, OfferTransactionResponse>(model, Endpoints.BITBAYOffer, marketCode);
        }
        /// <summary>
        /// Get active offers for the currency
        /// </summary>
        public async Task<AllActiveOffers> GetActiveOffers(string marketCode)
        {
            Logger.Trace($"Getting active BitBayOffers");

            return await GetMethodAsync<AllActiveOffers>(true, Endpoints.BITBAYOffer + "/" + marketCode);
        }
        /// <summary>
        /// Commissions and market configuration
        /// </summary>
        public async Task<GetConfigResponse> GetConfig(string marketCode)
        {
            Logger.Trace($"Getting Config");

            return await GetMethodAsync<GetConfigResponse>(true, Endpoints.BITBAYConfig, "/" + marketCode);
        }
        /// <summary>
        /// Returns a list of the highest buy bids and lowest selling bids.
        /// </summary>
        /// <param name="count">Setting the number of offers. Max 300(without param)</param>
        public async Task<OrderBookResponse> GetOrderBook(string marketCode, string count = "")
        {
            Logger.Trace($"Getting OrderBook");

            if (!string.IsNullOrEmpty(count))
            {
                return await GetMethodAsync<OrderBookResponse>(false, Endpoints.BITBAYOrderbookLimited, marketCode + "/" + count);
            }
            else
            {
                return await GetMethodAsync<OrderBookResponse>(false, Endpoints.BITBAYOrderbook, marketCode);
            }
        }

        public async Task<decimal> GetWalletBalance(string name)
        {
            Logger.Trace($"Getting Wallet Balance");

            var val = await GetMethodAsync<WalletBalanceResponse>(true, Endpoints.BITBAYBalance);

            if (val != null)
            {
                var funds = val.balances.FirstOrDefault(w => w.name == name);

                if (funds != null)
                    return funds.totalFunds;
            }
            return 0;
        }
        /// <summary>
        /// Returns all wallets available in the account along with the balance of funds
        /// </summary>
        public async Task<WalletBalanceResponse> GetWalletsBalance()
        {
            Logger.Trace($"Getting Wallets Balance");

            return await GetMethodAsync<WalletBalanceResponse>(true, Endpoints.BITBAYBalance);
        }
        /// <summary>
        /// Returns specific wallet in the account along with the balance of funds
        /// </summary>
        public async Task DeleteOffer(string marketCode, string id, string offerType, string rate)
        {
            Logger.Trace($"Deleting BitBayOffer");

            await DeleteMethodAsync(Endpoints.BITBAYOffer, marketCode, id, offerType, rate);
        }
    }
}
