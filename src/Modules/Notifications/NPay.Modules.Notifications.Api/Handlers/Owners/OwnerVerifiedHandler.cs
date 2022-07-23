using System.Threading;
using System.Threading.Tasks;
using NPay.Modules.Notifications.Api.Services;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.Handlers.Owners;

internal sealed class OwnerVerifiedHandler : IEventHandler<OwnerVerified>
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailResolver _emailResolver;

    public OwnerVerifiedHandler(IEmailSender emailSender, IEmailResolver emailResolver)
    {
        _emailSender = emailSender;
        _emailResolver = emailResolver;
    }

    public Task HandleAsync(OwnerVerified @event, CancellationToken cancellationToken = default)
        => _emailSender.SendAsync(_emailResolver.GetForOwner(@event.OwnerId), "owner_verified");
}