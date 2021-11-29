using Convey.MessageBrokers.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Notifications.Api;
using NPay.Modules.Users.Api;
using NPay.Modules.Users.Shared.Events;
using NPay.Modules.Wallets.Api;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared;
using NPay.Shared.Messaging;

namespace NPay.Bootstrapper
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddNotificationsModule();
            services.AddUsersModule();
            services.AddWalletsModule();
            services.AddSharedFramework(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSharedFramework();
            app.UseNotificationsModule();
            app.UseUsersModule();
            app.UseWalletsModule();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", ctx => ctx.Response.WriteAsync("NPay API"));
            });

            app.UseRabbitMq()
                .Subscribe<UserCreated>((s, e, _) => s.GetRequiredService<IAsyncEventDispatcher>().PublishAsync(e))
                .Subscribe<UserVerified>((s, e, _) => s.GetRequiredService<IAsyncEventDispatcher>().PublishAsync(e))
                .Subscribe<FundsAdded>((s, e, _) => s.GetRequiredService<IAsyncEventDispatcher>().PublishAsync(e))
                .Subscribe<FundsTransferred>((s, e, _) => s.GetRequiredService<IAsyncEventDispatcher>().PublishAsync(e))
                .Subscribe<OwnerVerified>((s, e, _) => s.GetRequiredService<IAsyncEventDispatcher>().PublishAsync(e))
                .Subscribe<WalletAdded>((s, e, _) => s.GetRequiredService<IAsyncEventDispatcher>().PublishAsync(e));
        }
    }
}
