using System;
using System.Threading.Tasks;
using NPay.Modules.Users.Shared.DTO;

namespace NPay.Modules.Users.Shared;

public interface IUsersModuleApi
{
    Task<UserDetailsDto> GetUserAsync(Guid userId);
    Task<UserDetailsDto> GetUserAsync(string email);
}