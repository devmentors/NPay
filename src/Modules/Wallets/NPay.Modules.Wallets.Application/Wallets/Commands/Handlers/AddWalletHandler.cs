using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;
using NPay.Modules.Wallets.Core.Wallets.Repositories;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Commands;
using NPay.Shared.Messaging;
using NPay.Shared.Time;

namespace NPay.Modules.Wallets.Application.Wallets.Commands.Handlers;

internal sealed class AddWalletHandler : ICommandHandler<AddWallet>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IClock _clock;
    private readonly IMessageBroker _messageBroker;
    private readonly ILogger<AddWalletHandler> _logger;

    public AddWalletHandler(IWalletRepository walletRepository, IClock clock, IMessageBroker messageBroker,
        ILogger<AddWalletHandler> logger)
    {
        _walletRepository = walletRepository;
        _clock = clock;
        _messageBroker = messageBroker;
        _logger = logger;
    }

    public async Task HandleAsync(AddWallet command, CancellationToken cancellationToken = default)
    {
        var now = _clock.CurrentDate();
        var wallet = Wallet.Create(command.WalletId, command.OwnerId, command.Currency, now);
        await _walletRepository.AddAsync(wallet);
        await _messageBroker.PublishAsync(new WalletAdded(wallet.Id, wallet.OwnerId, wallet.Currency),
            cancellationToken);
        _logger.LogInformation($"Added the wallet with ID: '{wallet.Id}' for an owner: '{wallet.OwnerId}'.");
    }
}