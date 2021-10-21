using System.Threading.Channels;
using NPay.Shared.Events;

namespace NPay.Shared.Messaging
{
    internal interface IEventChannel
    {
        ChannelReader<IEvent> Reader { get; }
        ChannelWriter<IEvent> Writer { get; }
    }
}