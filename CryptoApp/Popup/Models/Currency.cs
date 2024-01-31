using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Popup.Models
{
    public class Currency
    {
        public string CoinName { get; set; }
        public string Symbol { get; set; }
        public int Quantity { get; set; }
        public double PriceBought { get; set; }
    }
}
