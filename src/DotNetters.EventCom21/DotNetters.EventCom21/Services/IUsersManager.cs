using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetters.EventCom21.Services
{
    /// <summary>
    /// Gestión de usuarios de la aplicación
    /// </summary>
    public interface IUsersManager
    {
        /// <summary>
        /// Obtiene los usuarios que se han conectado al sistema desde su inicio
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetConnectedUsers();
    }
}