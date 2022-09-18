using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Wallets.Application.Services;
using NPay.Modules.Wallets.Shared;

[assembly: InternalsVisibleTo("NPay.Modules.Wallets.Infrastructure")]
namespace NPay.Modules.Wallets.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddTransient<IWalletsModuleApi, WalletsModuleApi>();
            
        return services;
    }
}