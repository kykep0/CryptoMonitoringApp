using CryptoApp.Helpers;
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
    class MainViewModel : BaseViewModel
    {
        private ObservableCollection<CoinModel> coinList;
        private List<int> shownCurrencyNumbersList = new List<int>() { 5, 10, 25, 50, 100 };
        private int shownCurrencyNumber;

        public ObservableCollection<CoinModel> CoinList
        {
            get { return coinList; }
            set
            {
                coinList = value;
                OnPropertyChanged(nameof(CoinList));
            }
        }
        public List<int> ShownCurrencyNumbersList
        {
            get { return shownCurrencyNumbersList; }
            set
            {
                shownCurrencyNumbersList = value;
                OnPropertyChanged(nameof(ShownCurrencyNumbersList));
            }
        }
        public int ShownCurrencyNumber
        {
            get { return shownCurrencyNumber; }
            set
            {
                shownCurrencyNumber = value;
                OnPropertyChanged(nameof(ShownCurrencyNumber));
                LoadData();
            }
        }

        public MainViewModel()
        {
            CoinList = new ObservableCollection<CoinModel>();
        }

        private async void LoadData()
        {
            using (var client = new HttpClient())
            {
                SetHttpClient(client);
                var endpoint = $"coins/markets?vs_currency=usd&order=market_cap_desc&per_page={ShownCurrencyNumber}&page=1&sparkline=false";

                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var coinList = new List<CoinModel>();
                        var coins = JArray.Parse(json);
                        CoinList = new ObservableCollection<CoinModel>(coins.Select(coin => new CoinModel
                        {
                            Id = coin.Value<string>("id"),
                            Name = coin.Value<string>("name"),
                            Symbol = coin.Value<string>("symbol"),
                            CurrentPriceUsd = coin.Value<decimal>("current_price"),
                            MarketCap = coin.Value<decimal>("market_cap")
                        }));
                    }
                    catch (JsonException ex)
                    {
                        throw new Exception("Invalid JSON response.", ex);
                    }
                }
                else
                {
                    throw new Exception("API request failed.");
                }
            }
        }
    }
}
