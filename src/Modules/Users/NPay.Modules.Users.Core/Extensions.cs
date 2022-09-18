using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Users.Core.DAL;
using NPay.Modules.Users.Core.Services;
using NPay.Modules.Users.Shared;
using NPay.Shared.Database;

namespace NPay.Modules.Users.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddPostgres<UsersDbContext>();
        services.AddTransient<IUsersService, UsersService>();
        services.AddTransient<IUsersModuleApi, UsersModuleApi>();
            
        return services;
    }
}