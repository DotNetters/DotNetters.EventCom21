using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetters.EventCom21.Services
{
    public class Greeter : IGreeter
    {
        public string ComposeGreeting(string name = "Mundo")
        {
            var result = string.Empty;

            result = $"Hola {name}";

            return result;
        }
    }
}
