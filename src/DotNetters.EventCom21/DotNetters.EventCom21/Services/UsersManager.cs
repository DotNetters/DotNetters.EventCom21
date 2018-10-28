using DotNetters.EventCom21.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetters.EventCom21.Services
{
    public class UsersManager : IUsersManager
    {
        static readonly HttpClient httpClient;

        const string REST_URL = "http://eventcom.azurewebsites.net/api/";

        /// <summary>
        /// Inicializador estático de <see cref="MessageSender"/>
        /// </summary>
        static UsersManager()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(REST_URL)
            };
        }

        public async Task<IEnumerable<string>> GetConnectedUsersAsync()
        {
            var result = new List<string>();

            HttpResponseMessage response = null;
            response = await httpClient.GetAsync("users");

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<string>>(resp);
            }

            return result;
        }
    }
}
