using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Wallets.Application.Clients;

[assembly: InternalsVisibleTo("NPay.Modules.Wallets.Infrastructure")]
namespace NPay.Modules.Wallets.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddSingleton<IUsersApiModuleClient, UsersApiModuleClient>();
            
            return services;
        }
    }
}