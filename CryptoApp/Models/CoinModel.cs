using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Models
{
    class CoinModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
        public double MarketCap { get; set; }
    }
}
