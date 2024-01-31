using SQLite;

namespace CryptoApp.Models
{
    public class Exchange
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CoinId { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public double PriceAtTime { get; set; }
        public double Average { get; set; }
        public double CurrentPrice { get; set; }
    }
}
