using EquityX_L00160463.Models;
using EquityX_L00160463.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityX_L00160463.Services
{
    public class AssetDataService : IAssetDataService
    {
        // private string _mockApiBaseUrl = "https://localhost:7052/api/";
        private string _apiBaseUrl = "https://yfapi.net/v6/finance/quote?region=US&lang=en&symbols=META,AMZN,MSFT,TSLA,AAPL,BTC-USD,ETH-USD,USDT-USD,BNB-USD,SOL-USD";
        private string API_KEY = "HFxyRZz4cc73DYba7hkQD5EQUsIidi1gaYpt3AQW";
        private readonly HttpClient _httpClient;
        List<Asset> _assetQuotes = new List<Asset>();

        public AssetDataService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
        }


        public async Task<List<Asset>> GetAssetsData()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress + "v6/finance/quote?region=US&lang=en&symbols=META,AMZN,MSFT,TSLA,AAPL,BTC-USD,ETH-USD,USDT-USD,BNB-USD,SOL-USD");
                request.Headers.Add("X-API-KEY", API_KEY);

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseBody);
                // Convert to Asset objects
                _assetQuotes = ConvertToAssetObjects(myDeserializedClass);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return _assetQuotes;

        }

        public List<Asset> ConvertToAssetObjects(Root root)
        {
            List<Asset> assetQuotes = new List<Asset>();

            if (root != null && root.quoteResponse != null && root.quoteResponse.result != null)
            {
                foreach (var result in root.quoteResponse.result)
                {
                    // Convert each result into an Asset object
                    Asset assetQuote = new Asset
                    {
                        Symbol = result.symbol,
                        DisplayName = result.displayName,
                        RegularMarketChange = result.regularMarketChange,
                        RegularMarketChangePercent = result.regularMarketChangePercent,
                        FiftyTwoWeekLow = result.fiftyTwoWeekLow,
                        FiftyTwoWeekHigh = result.fiftyTwoWeekHigh,
                        CoinImageUrl = result.coinImageUrl,
                        ShortName = result.shortName,
                        QuoteType = result.quoteType,
                        MarketState = result.marketState,
                        RegularMarketOpen = result.regularMarketOpen,
                        RegularMarketDayHigh = result.regularMarketDayHigh,
                        RegularMarketPrice = result.regularMarketPrice

                    };

                    // Add the Asset to the list
                    assetQuotes.Add(assetQuote);
                }
            }

            return assetQuotes;
        }
    }
}