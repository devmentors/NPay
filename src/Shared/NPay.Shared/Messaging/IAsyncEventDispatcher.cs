using System.Threading;
using System.Threading.Tasks;
using NPay.Shared.Events;

namespace NPay.Shared.Messaging;

internal interface IAsyncEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent;
}