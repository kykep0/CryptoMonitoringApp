using CryptoApp.Models;
using Newtonsoft.Json;
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
        private const string BaseUrl = "https://api.coingecko.com/api/v3";

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
            //using (var client = new HttpClient())
            //{
            //    var json = await client.GetStringAsync($"{BaseUrl}/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false&locale=en");
            //    var cryptos = JsonConvert.DeserializeObject<CoinModel[]>(json);
            //    CoinList = new ObservableCollection<CoinModel>(cryptos);
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
