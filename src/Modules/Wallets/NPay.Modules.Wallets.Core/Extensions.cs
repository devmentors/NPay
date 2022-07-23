using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Wallets.Core.Wallets.Services;

[assembly: InternalsVisibleTo("NPay.Modules.Wallets.Application")]
[assembly: InternalsVisibleTo("NPay.Modules.Wallets.Infrastructure")]
namespace NPay.Modules.Wallets.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddSingleton<ICurrencyResolver, CurrencyResolver>();
            
        return services;
    }
}