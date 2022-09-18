using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NPay.Modules.Users.Shared.Events;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;
using NPay.Modules.Wallets.Core.Wallets.Repositories;
using NPay.Modules.Wallets.Core.Wallets.Services;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Events;
using NPay.Shared.Messaging;
using NPay.Shared.Time;

namespace NPay.Modules.Wallets.Application.Wallets.ExternalEvents.Handlers;

internal sealed class UserVerifiedHandler : IEventHandler<UserVerified>
{
    private readonly IWalletRepository _walletRepository;
    private readonly ICurrencyResolver _currencyResolver;
    private readonly IClock _clock;
    private readonly IMessageBroker _messageBroker;
    private readonly ILogger<UserVerifiedHandler> _logger;

    public UserVerifiedHandler(IWalletRepository walletRepository, ICurrencyResolver currencyResolver,
        IClock clock, IMessageBroker messageBroker, ILogger<UserVerifiedHandler> logger)
    {
        _walletRepository = walletRepository;
        _currencyResolver = currencyResolver;
        _clock = clock;
        _messageBroker = messageBroker;
        _logger = logger;
    }

    public async Task HandleAsync(UserVerified @event, CancellationToken cancellationToken = default)
    {
        var now = _clock.CurrentDate();
        var currency = _currencyResolver.Resolve(@event.Nationality);
        var wallet = Wallet.Create(@event.UserId, currency, now);
        await _walletRepository.AddAsync(wallet);
        await _messageBroker.PublishAsync(new WalletAdded(wallet.Id, wallet.OwnerId, wallet.Currency),
            cancellationToken);
        _logger.LogInformation($"Added the wallet with ID: '{wallet.Id}' for an owner: '{wallet.OwnerId}'.");
    }
}