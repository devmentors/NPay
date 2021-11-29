using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Notifications.Api.Services;

namespace NPay.Modules.Notifications.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddNotificationsModule(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<IEmailResolver, EmailResolver>();
            
            return services;
        }
        
        public static IApplicationBuilder UseNotificationsModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}