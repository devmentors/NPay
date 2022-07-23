using System.Threading;
using System.Threading.Tasks;
using NPay.Shared.Events;

namespace NPay.Shared.Messaging;

internal sealed class AsyncEventDispatcher : IAsyncEventDispatcher
{
    private readonly IEventChannel _channel;

    public AsyncEventDispatcher(IEventChannel channel)
    {
        _channel = channel;
    }

    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent
    {
        await _channel.Writer.WriteAsync(@event, cancellationToken);
    }
}