using Microsoft.Extensions.DependencyInjection;

namespace NPay.Shared.Messaging;

internal static class Extensions
{
    private const string SectionName = "messaging";
        
    public static IServiceCollection AddMessaging(this IServiceCollection services)
    {
        services.AddTransient<IMessageBroker, InMemoryMessageBroker>();
        services.AddTransient<IAsyncEventDispatcher, AsyncEventDispatcher>();
        services.AddSingleton<IEventChannel, EventChannel>();
        services.AddHostedService<EventDispatcherJob>();
            
        return services;
    }
}