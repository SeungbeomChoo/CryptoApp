using Newtonsoft.Json;

namespace CryptoApp.Models
{
    public class CryptoCurrency
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("market_cap")]
        public double MarketCap { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public double Pricechange24hPercentage { get; set; }

        [JsonProperty("current_price")]
        public double CurrentPrice { get; set; }

        [JsonProperty("market_cap_rank")]
        public int MarketCapRank { get; set; }

    }
}
