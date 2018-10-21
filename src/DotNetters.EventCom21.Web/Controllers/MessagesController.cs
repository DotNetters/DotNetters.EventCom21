using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnetters.EventCom21.Web.Models;
using DotNetters.EventCom21.Web.Hubs;
using DotNetters.EventCom21.Web.UserRegistration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DotNetters.EventCom21.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        IHubContext<MessagingHub> MessagingHubContext { get; set; }

        /// <summary>
        /// Inicializa una instancia de <see cref="MessagesController"/>
        /// </summary>
        /// <param name="messagingHubContext"></param>
        public MessagesController(IHubContext<MessagingHub> messagingHubContext)
        {
            MessagingHubContext = messagingHubContext;
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MessagePost messageData)
        {
            await UsersRegister.AddUser(messageData.User);

            var dateStr = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";

            await MessagingHubContext.Clients.All.SendAsync("Send", messageData.User, messageData.Message, dateStr);

            return Ok(messageData);
        }
    }
}