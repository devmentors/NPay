using System.Threading;
using System.Threading.Tasks;
using NPay.Modules.Notifications.Api.Services;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.Handlers.Wallets;

internal sealed class FundsTransferredHandler : IEventHandler<FundsTransferred>
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailResolver _emailResolver;

    public FundsTransferredHandler(IEmailSender emailSender, IEmailResolver emailResolver)
    {
        _emailSender = emailSender;
        _emailResolver = emailResolver;
    }

    public Task HandleAsync(FundsTransferred @event, CancellationToken cancellationToken = default)
        => Task.WhenAll(_emailSender.SendAsync(_emailResolver.GetForOwner(@event.FromWalletId), "funds_deducted"),
            _emailSender.SendAsync(_emailResolver.GetForOwner(@event.ToWalletId), "funds_added"));
}