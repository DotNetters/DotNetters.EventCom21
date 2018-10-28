using DotNetters.EventCom21.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetters.EventCom21.Services
{
    public class MessageSender : IMessageSender
    {
        static readonly HttpClient httpClient;

        const string REST_URL = "http://eventcom.azurewebsites.net/api/";

        /// <summary>
        /// Inicializador estático de <see cref="MessageSender"/>
        /// </summary>
        static MessageSender()
        {
            httpClient = new HttpClient
            {
                MaxResponseContentBufferSize = 256000,
                BaseAddress = new Uri(REST_URL)
            };
        }
        public async Task<(string message, bool success)> SendAsync(string user, string message)
        {
            var onError = false;
            var result = string.Empty;

            try
            {
                var msgData = new MessageData() { User = user, Message = message };
                var json = JsonConvert.SerializeObject(msgData);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await httpClient.PostAsync("messages", content);

                if (!response.IsSuccessStatusCode)
                {
                    result = response.ToString();
                    onError = true;
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                onError = true;
            }
            finally
            {
                if (!onError)
                {
                    result = "Mensaje enviado correctamente";
                }
                else
                {
                    result = "Error";
                }
            }

            return (result, !onError);
        }
    }
}
