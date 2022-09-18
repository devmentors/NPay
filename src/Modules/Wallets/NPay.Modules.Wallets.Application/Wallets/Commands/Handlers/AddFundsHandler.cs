using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NPay.Modules.Wallets.Core.Wallets.Exceptions;
using NPay.Modules.Wallets.Core.Wallets.Repositories;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Commands;
using NPay.Shared.Messaging;
using NPay.Shared.Time;

namespace NPay.Modules.Wallets.Application.Wallets.Commands.Handlers;

internal sealed class AddFundsHandler : ICommandHandler<AddFunds>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IClock _clock;
    private readonly IMessageBroker _messageBroker;
    private readonly ILogger<AddFundsHandler> _logger;

    public AddFundsHandler(IWalletRepository walletRepository, IClock clock, IMessageBroker messageBroker,
        ILogger<AddFundsHandler> logger)

    {
        _walletRepository = walletRepository;
        _clock = clock;
        _messageBroker = messageBroker;
        _logger = logger;
    }

    public async Task HandleAsync(AddFunds command, CancellationToken cancellationToken = default)
    {
        var (walletId, amount) = command;
        var wallet = await _walletRepository.GetAsync(walletId);
        if (wallet is null)
        {
            throw new WalletNotFoundException(walletId);
        }

        var now = _clock.CurrentDate();
        var transfer = wallet.AddFunds(new TransferId(), amount, now);
        await _walletRepository.UpdateAsync(wallet);
        await _messageBroker.PublishAsync(new FundsAdded(walletId, wallet.OwnerId, transfer.Currency,
            transfer.Amount), cancellationToken);
        _logger.LogInformation($"Added {transfer.Amount} {transfer.Currency} to the wallet: '{wallet.Id}'");
    }
}