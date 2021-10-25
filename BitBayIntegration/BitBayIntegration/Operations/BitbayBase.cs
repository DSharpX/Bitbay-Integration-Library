using BitBayIntegration.Coverters;
using BitBayIntegration.Logs;
using BitBayIntegration.Resources;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace BitBayIntegration.Operations
{
    public class BitbayBase
    {
        protected RestClient client = new RestClient("https://api.bitbay.net/rest");
        protected RestRequest request;

        protected async Task<T> GetMethodAsync<T>(bool requireAuthorization, string endPoint, string marketCode = "")
        {

            if (string.IsNullOrEmpty(marketCode))
                request = new RestRequest(endPoint, Method.GET);
            else
                request = new RestRequest(endPoint + marketCode, Method.GET);

            if (requireAuthorization)
            {
                var unixTimeStamp = TimeConverter.GetUnixTimestamp().ToString();

                var stringToHash = Credentials.ApiPublicKey + unixTimeStamp;

                var apiHash = HashConverter.ToHMACSHA512(Credentials.ApiPrivateKey, stringToHash);

                request.AddHeader("API-Key", Credentials.ApiPublicKey);
                request.AddHeader("API-Hash", apiHash);
                request.AddHeader("operation-id", Guid.NewGuid().ToString());
                request.AddHeader("Request-Timestamp", TimeConverter.GetUnixTimestamp().ToString());
                request.AddHeader("Content-Type", "application/json");
            }

            try
            {
                var queryResult = await client.ExecuteAsync(request);

                return JsonConvert.DeserializeObject<T>(queryResult.Content);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return default(T);
        }

        protected async Task<T1> PostMethodAsync<T, T1>(T item, string endPoint, string marketCode = "")
        {
            RestRequest request;

            if (string.IsNullOrEmpty(marketCode))
                request = new RestRequest(endPoint, Method.GET);
            else
                request = new RestRequest(endPoint + marketCode, Method.POST);


            var unixTimeStamp = TimeConverter.GetUnixTimestamp().ToString();

            var stringToHash = Credentials.ApiPublicKey + unixTimeStamp + JsonConvert.SerializeObject(item);

            var apiHash = HashConverter.ToHMACSHA512(Credentials.ApiPrivateKey, stringToHash);

            request.AddHeader("API-Key", Credentials.ApiPublicKey);
            request.AddHeader("API-Hash", apiHash);
            request.AddHeader("operation-id", Guid.NewGuid().ToString());
            request.AddHeader("Request-Timestamp", unixTimeStamp);
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(item);

            try
            {
                var queryResult = await client.ExecuteAsync(request);

                return JsonConvert.DeserializeObject<T1>(queryResult.Content);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return default(T1);
        }

        protected async Task DeleteMethodAsync(string endPoint, string marketCode, string offerId, string offerType, string rate)
        {
            RestRequest request;

            request = new RestRequest($"{endPoint}{marketCode}/{offerId}/{offerType}/{rate}", Method.DELETE);

            var unixTimeStamp = TimeConverter.GetUnixTimestamp().ToString();

            var stringToHash = Credentials.ApiPublicKey + unixTimeStamp;

            var apiHash = HashConverter.ToHMACSHA512(Credentials.ApiPrivateKey, stringToHash);

            request.AddHeader("API-Key", Credentials.ApiPublicKey);
            request.AddHeader("API-Hash", apiHash);
            request.AddHeader("operation-id", Guid.NewGuid().ToString());
            request.AddHeader("Request-Timestamp", unixTimeStamp);
            request.AddHeader("Content-Type", "application/json");

            try
            {
                await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
