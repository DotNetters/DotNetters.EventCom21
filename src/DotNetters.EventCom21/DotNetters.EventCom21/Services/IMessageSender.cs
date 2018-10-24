using System.Threading.Tasks;

namespace DotNetters.EventCom21.Services
{
    public interface IMessageSender
    {
        Task<(string message, bool success)> SendAsync(string user, string message);
    }
}