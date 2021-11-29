using System.Threading;
using System.Threading.Tasks;
using Convey.MessageBrokers;
using Humanizer;
using Microsoft.Extensions.Logging;
using NPay.Shared.Events;

namespace NPay.Shared.Messaging
{
    internal sealed class InMemoryMessageBroker : IMessageBroker
    {
        private readonly IBusPublisher _busPublisher;
        private readonly ILogger<InMemoryMessageBroker> _logger;

        public InMemoryMessageBroker(IBusPublisher busPublisher, ILogger<InMemoryMessageBroker> logger)
        {
            _busPublisher = busPublisher;
            _logger = logger;
        }

        public async Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default)
        {
            var name = @event.GetType().Name.Underscore();
            _logger.LogInformation("Publishing an event: {Name}...", name);
            await _busPublisher.PublishAsync(@event);
        }
    }
}