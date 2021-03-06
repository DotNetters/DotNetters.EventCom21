﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetters.EventCom21.Web.UserRegistration;
using Microsoft.AspNetCore.SignalR;

namespace DotNetters.EventCom21.Web.Hubs
{
    /// <summary>
    /// Hub para la emisión en tiempo real de los mensajes recibidos desde la APP
    /// </summary>
    public class MessagingHub : Hub
    {
        /// <summary>
        /// Emite un mensaje a todos los clientes del HUB
        /// </summary>
        /// <param name="user">Nick del usuario que envía el mensaje</param>
        /// <param name="message">Texto del mensaje</param>
        /// <returns></returns>
        public async Task Send(string user, string message)
        {
            await UsersRegister.AddUser(user);
            var dateStr = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";
            await Clients.All.SendAsync("Send", user, message, dateStr);
        }
    }
}
