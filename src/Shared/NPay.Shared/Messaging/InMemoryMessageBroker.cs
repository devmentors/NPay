using System.Threading;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.Extensions.Logging;
using NPay.Shared.Events;

namespace NPay.Shared.Messaging
{
    internal sealed class InMemoryMessageBroker : IMessageBroker
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly ILogger<InMemoryMessageBroker> _logger;

        public InMemoryMessageBroker(IEventDispatcher eventDispatcher, ILogger<InMemoryMessageBroker> logger)
        {
            _eventDispatcher = eventDispatcher;
            _logger = logger;
        }

        public async Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default)
        {
            var name = @event.GetType().Name.Underscore();
            _logger.LogInformation("Publishing an event: {Name}...", name);
            await _eventDispatcher.PublishAsync(@event, cancellationToken);
        }
    }
}