using System.Threading.Tasks;
using NPay.Modules.Wallets.Application.Clients.DTO;

namespace NPay.Modules.Wallets.Application.Clients
{
    internal sealed class UsersApiModuleClient : IUsersApiModuleClient
    {
        // TODO: Implement module client
        public Task<UserDetailsDto> GetUserAsync(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}