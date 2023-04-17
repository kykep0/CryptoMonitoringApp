using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Helpers
{
    public interface IBaseViewModel
    {
        void SetHttpClient(HttpClient client);
    }

    class BaseViewModel : IBaseViewModel
    {
        public void SetHttpClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.75 Safari/537.36");
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
        }
    }
}