using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;

namespace CryptoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd";
        //    var client = new HttpClient();
        //    var response = await client.GetAsync(url);
        //    var responseContent = await response.Content.ReadAsStringAsync();
        //    var data = JsonConvert.DeserializeObject<dynamic>(responseContent);
        //    var price = data.bitcoin.usd;
        //    PriceTextBlock.Text = $"1 BTC = {price}$";
        //}
    }
}
