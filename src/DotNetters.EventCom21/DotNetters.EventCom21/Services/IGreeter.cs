using System.Threading.Tasks;

namespace DotNetters.EventCom21.Services
{
    public interface IGreeter
    {
        string ComposeGreeting(string name = "Mundo");
    }
}