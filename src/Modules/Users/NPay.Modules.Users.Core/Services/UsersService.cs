using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NPay.Modules.Users.Core.DAL;
using NPay.Modules.Users.Core.Entities;
using NPay.Modules.Users.Core.Exceptions;
using NPay.Modules.Users.Shared.DTO;
using NPay.Modules.Users.Shared.Events;
using NPay.Shared.Messaging;
using NPay.Shared.Time;

namespace NPay.Modules.Users.Core.Services;

internal sealed class UsersService : IUsersService
{
    private readonly UsersDbContext _dbContext;
    private readonly IMessageBroker _messageBroker;
    private readonly IClock _clock;
    private readonly ILogger<UsersService> _logger;

    public UsersService(UsersDbContext dbContext, IMessageBroker messageBroker, IClock clock,
        ILogger<UsersService> logger)
    {
        _dbContext = dbContext;
        _messageBroker = messageBroker;
        _clock = clock;
        _logger = logger;
    }

    public async Task<UserDetailsDto> GetAsync(Guid userId)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
            
        // TODO: Make use of custom mapping interface or AutoMapper, Mapster etc.
            
        return user is null ? null : MapToDetailsDto(user);
    }

    public async Task<UserDetailsDto> GetAsync(string email)
    {
        // TODO: Additional email validation
        email = email?.ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new InvalidEmailException(email);
        }
            
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
            
        return user is null ? null : MapToDetailsDto(user);
    }

    public async Task<IReadOnlyList<UserDto>> BrowseAsync()
    {
        var users = await _dbContext.Users.ToListAsync();

        // TODO: Implement pagination, sorting etc.
            
        return users.Select(MapToDto).ToList();
    }

    public async Task AddAsync(UserDetailsDto dto)
    {
        var email = dto.Email.ToLowerInvariant();
        if (await _dbContext.Users.AnyAsync(x => x.Email == email))
        {
            throw new UserAlreadyExistsException(email);
        }
            
        // TODO: Additional validation for the remaining properties
        if (string.IsNullOrWhiteSpace(dto.FullName))
        {
            throw new InvalidFullNameException(dto.FullName);
        }
            
        if (string.IsNullOrWhiteSpace(dto.Address))
        {
            throw new InvalidAddressException(dto.Address);
        }
            
        var user = new User(dto.UserId, email, dto.FullName, dto.Address,
            dto.Nationality, dto.Identity, _clock.CurrentDate());
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        await _messageBroker.PublishAsync(new UserCreated(user.Id, user.Email, user.FullName, user.Nationality));
        _logger.LogInformation($"Created the user with ID: '{dto.UserId}'.");
    }

    public async Task VerifyAsync(Guid userId)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        user.Verify(_clock.CurrentDate());
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
        await _messageBroker.PublishAsync(new UserVerified(user.Id, user.Email, user.Nationality));
        _logger.LogInformation($"Verified the user with ID: '{user.Id}'.");
    }

    // TODO: Extract to the dedicated "mapper" interfaces or extension methods
        
    private static UserDto MapToDto(User user)=> Map<UserDto>(user);

    private static UserDetailsDto MapToDetailsDto(User user)
    {
        var dto = Map<UserDetailsDto>(user);
        dto.Address = user.Address;
        dto.Identity = user.Identity;

        return dto;
    }

    private static T Map<T>(User user) where T : UserDto, new()
        => new()
        {
            UserId = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            Nationality = user.Nationality,
            State = user.VerifiedAt.HasValue ? "verified" : "unverified",
            CreatedAt = user.CreatedAt
        };
}