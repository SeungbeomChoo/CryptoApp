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
        public double? Pricechange24hPercentage { get; set; }

        [JsonProperty("current_price")]
        public double CurrentPrice { get; set; }

        [JsonProperty("market_cap_rank")]
        public int MarketCapRank { get; set; }

        [JsonProperty("high_24h")]
        public double? DayHourHigh { get; set; }

        [JsonProperty("low_24h")]
        public double? DayHourLow { get; set; }

        [JsonProperty("ath")]
        public double? AllTimeHigh { get; set; }

        [JsonProperty("atl")]
        public double? AllTimeLow { get; set; }

        [JsonProperty("ath_change_percentage")]
        public double? AllTimeHighPercentage { get; set; }

        [JsonProperty("atl_change_percentage")]
        public double? AllTimeLowPercentage { get; set; }

        [JsonProperty("ath_date")]
        public DateTime AllTimeHighPercentageDate { get; set; }

        [JsonProperty("atl_date")]
        public DateTime AllTimeLowPercentageDate { get; set; }
    }
}
