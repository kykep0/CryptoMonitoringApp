using CryptoApp.Helpers;
using CryptoApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.ViewModels
{
    class DetailedViewModel : BaseViewModel
    {
        private string selectedCoinId;
        private CoinModel selectedCoin;

        public string SelectedCoinId
        {
            get { return selectedCoinId; }
            set
            {
                selectedCoinId = value;
                OnPropertyChanged(nameof(SelectedCoinId));
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
        public DetailedViewModel(string selectedCoinId)
        {
            SelectedCoinId = selectedCoinId;
            LoadData();
        }

        private async void LoadData()
        {
            using (var client = new HttpClient())
            {
                SetHttpClient(client);
                var endpoint = $"coins/{SelectedCoinId}?localization=false&tickers=true&market_data=true";

                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var coin = JObject.Parse(json);
                        var image = coin.Value<JObject>("image");
                        var description = coin.Value<JObject>("description");
                        var links = coin.Value<JObject>("links");
                        var marketData = coin.Value<JObject>("market_data");

                        SelectedCoin = new CoinModel
                        {
                            Id = coin.Value<string>("id"),
                            Name = coin.Value<string>("name"),
                            Symbol = coin.Value<string>("symbol"),
                            Image = image.Value<string>("large"),
                            Description = description.Value<string>("en"),
                            HomePage = links.Value<JArray>("homepage")[0].ToString(),
                            GitHub = links.Value<JObject>("repos_url").Value<JArray>("github")[0].ToString(),
                            Twitter = "https://twitter.com/" + links.Value<string>("twitter_screen_name"),
                            Reddit = links.Value<string>("subreddit_url"),
                            CurrentPrices = marketData.Value<JObject>("current_price").ToObject<Dictionary<string, decimal>>(),
                            AllTimeHighs = marketData.Value<JObject>("ath").ToObject<Dictionary<string, decimal>>(),
                            AllTimeHighChanges = marketData.Value<JObject>("ath_change_percentage").ToObject<Dictionary<string, decimal>>(),
                            AllTimeHighDates = marketData.Value<JObject>("ath_date").ToObject<Dictionary<string, DateTime>>(),
                            AllTimeLows = marketData.Value<JObject>("atl").ToObject<Dictionary<string, decimal>>(),
                            AllTimeLowChanges = marketData.Value<JObject>("atl_change_percentage").ToObject<Dictionary<string, decimal>>(),
                            AllTimeLowDates = marketData.Value<JObject>("atl_date").ToObject<Dictionary<string, DateTime>>(),
                            MarketCapAll = marketData.Value<JObject>("market_cap").ToObject<Dictionary<string, decimal>>(),
                            MarketRank = marketData.Value<int>("market_cap_rank"),
                            TotalVolume = marketData.Value<JObject>("total_volume").ToObject<Dictionary<string, decimal>>(),
                            DayHighs = marketData.Value<JObject>("high_24h").ToObject<Dictionary<string, decimal>>(),
                            DayLows = marketData.Value<JObject>("low_24h").ToObject<Dictionary<string, decimal>>(),
                            DayChange = marketData.Value<double>("price_change_percentage_24h"),
                            WeekChange = marketData.Value<double>("price_change_percentage_7d"),
                            TwoWeeksChange = marketData.Value<double>("price_change_percentage_14d"),
                            MonthChange = marketData.Value<double>("price_change_percentage_30d"),
                            TwoMothsChange = marketData.Value<double>("price_change_percentage_60d"),
                            HalfYearChange = marketData.Value<double>("price_change_percentage_200d"),
                            YearChange = marketData.Value<double>("price_change_percentage_1y"),
                        };
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
