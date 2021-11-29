using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NPay.Modules.Users.Core.DTO;

namespace NPay.Modules.Users.Core.Services
{
    public interface IUsersService
    {
        Task<UserDetailsDto> GetAsync(Guid userId);
        Task<UserDetailsDto> GetAsync(string email);
        Task<IReadOnlyList<UserDto>> BrowseAsync();
        Task AddAsync(UserDetailsDto dto);
        Task VerifyAsync(Guid userId);
    }
}