using System.Threading;
using System.Threading.Tasks;
using NPay.Shared.Events;

namespace NPay.Shared.Messaging
{
    public interface IMessageBroker
    {
        Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default);
    }
}