using CryptoApp.Models;
using CryptoApp.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Repositories
{
    public class CoinGeckoRepository : ICoinGeckoRepository
    {
        private static string GeckoURL = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false";
        private HttpClient _client = new HttpClient();

        public async Task<List<CryptoCurrency>> GetTopCryptoCurrencies()
        {
            var list = new List<CryptoCurrency>();
            try 
            {
                //var response = await _client.GetStringAsync(GeckoURL);
                //list = JsonConvert.DeserializeObject<List<CryptoCurrency>>(response);
                list = JsonConvert.DeserializeObject<List<CryptoCurrency>>(MockData.MOCKJSON);
            }
            catch(Exception e)
            {
                throw e;
            }

            return list;
        }

        public async Task<List<CryptoCurrency>> GetAllCryptoCurrencies()
        {
            var list = new List<CryptoCurrency>();
            try
            {
                //var response = await _client.GetStringAsync(GeckoURL);
                //list = JsonConvert.DeserializeObject<List<CryptoCurrency>>(response);
                list = JsonConvert.DeserializeObject<List<CryptoCurrency>>(MockDataForSearch.MockAllCoinsJSON);
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }
    }
}
