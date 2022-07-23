using System.Threading;
using System.Threading.Tasks;
using NPay.Modules.Notifications.Api.Services;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.Handlers.Wallets;

internal sealed class WalletAddedHandler : IEventHandler<WalletAdded>
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailResolver _emailResolver;

    public WalletAddedHandler(IEmailSender emailSender, IEmailResolver emailResolver)
    {
        _emailSender = emailSender;
        _emailResolver = emailResolver;
    }

    public Task HandleAsync(WalletAdded @event, CancellationToken cancellationToken = default)
        => _emailSender.SendAsync(_emailResolver.GetForOwner(@event.OwnerId), "wallet_added");
}