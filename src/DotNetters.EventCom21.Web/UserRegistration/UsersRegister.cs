using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetters.EventCom21.Web.UserRegistration
{
    public static class UsersRegister
    {
        static ICollection<string> Users { get; set; } = new List<string>();

        public static async Task AddUser(string userNick)
        {
            await Task.Run(() =>
            {
                var exists = Users.Contains(userNick);
                if (!exists)
                    Users.Add(userNick);
            });
        }

        public static async Task<IEnumerable<string>> GetUsers()
        {
            var result = (IEnumerable<string>)null;
            await Task.Run(() =>
            {
                result = Users.OrderBy(u => u);
            });

            return result;
        }
    }
}
