using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Models
{
    class CoinModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal CurrentPriceUsd { get; set; }
        public decimal MarketCap { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string HomePage { get; set; }
        public string GitHub { get; set; }
        public string Twitter { get; set; }
        public string Reddit { get; set; }
        public int MarketRank { get; set; }
        public Dictionary<string, decimal> CurrentPrices { get; set; }
        public Dictionary<string, decimal> AllTimeHighs { get; set; }
        public Dictionary<string, decimal> AllTimeHighChanges { get; set; }
        public Dictionary<string, DateTime> AllTimeHighDates { get; set; }
        public Dictionary<string, decimal> AllTimeLows { get; set; }
        public Dictionary<string, decimal> AllTimeLowChanges { get; set; }
        public Dictionary<string, DateTime> AllTimeLowDates { get; set; }
        public Dictionary<string, decimal> TotalVolume { get; set; }
        public Dictionary<string, decimal> DayHighs { get; set; }
        public Dictionary<string, decimal> DayLows { get; set; }
        public double DayChange { get; set; }
        public double WeekChange { get; set; }
        public double TwoWeeksChange { get; set; }
        public double MonthChange { get; set; }
        public double TwoMothsChange { get; set; }
        public double HalfYearChange { get; set; }
        public double YearChange { get; set; }
        public List<double> WeekSparkline { get; set; }
        public Dictionary<string, decimal> MarketCapAll { get; set; }

    }
}
