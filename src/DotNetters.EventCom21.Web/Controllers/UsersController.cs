using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetters.EventCom21.Web.UserRegistration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetters.EventCom21.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        public async Task<IActionResult> Get()
        {
            return Ok(await UsersRegister.GetUsers());
        }
    }
}