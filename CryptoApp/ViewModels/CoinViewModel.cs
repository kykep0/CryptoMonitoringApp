using CryptoApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.ViewModels
{
    class CoinViewModel : INotifyPropertyChanged
    {
        private const string baseUrl = "https://api.coingecko.com/api/v3/";

        private ObservableCollection<CoinModel> coinList;
        private CoinModel selectedCoin;

        public ObservableCollection<CoinModel> CoinList
        {
            get { return coinList; }
            set
            {
                coinList = value;
                OnPropertyChanged(nameof(CoinList));
            }
        }
        public CoinModel SelectedCoin
        {
            get { return selectedCoin; }
            set
            {
                selectedCoin = value;
                OnPropertyChanged(nameof(SelectedCoin));
            }
        }

        public CoinViewModel()
        {
            CoinList = new ObservableCollection<CoinModel>();
            LoadData();
        }

        private async void LoadData()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.75 Safari/537.36");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                var endpoint = $"{baseUrl}coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false";

                var response = await client.GetAsync(endpoint);
                var json = await response.Content.ReadAsStringAsync();

                var coinList = new List<CoinModel>();
                var coins = JArray.Parse(json);

                CoinList = new ObservableCollection<CoinModel>(coins.Select(coin => new CoinModel
                {
                    Name = coin.Value<string>("name"),
                    Symbol = coin.Value<string>("symbol"),
                    CurrentPrice = coin.Value<decimal>("current_price"),
                    MarketCap = coin.Value<decimal>("market_cap")
                }));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
