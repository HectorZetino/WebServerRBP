using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebServicesView.Helper
{
    public class RsbAPi
    {
        public HttpClient Initial() {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44355/");
            return client;
        }
    }
}
