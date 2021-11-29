using System.Threading.Tasks;
using NPay.Modules.Wallets.Application.Clients.DTO;

namespace NPay.Modules.Wallets.Application.Clients
{
    public interface IUsersApiModuleClient
    {
        Task<UserDetailsDto> GetUserAsync(string email);
    }
}