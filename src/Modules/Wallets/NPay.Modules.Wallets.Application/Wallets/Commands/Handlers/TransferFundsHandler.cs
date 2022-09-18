using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NPay.Modules.Wallets.Core.Wallets.Exceptions;
using NPay.Modules.Wallets.Core.Wallets.Repositories;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Commands;
using NPay.Shared.Messaging;
using NPay.Shared.Time;

namespace NPay.Modules.Wallets.Application.Wallets.Commands.Handlers;

internal sealed class TransferFundsHandler : ICommandHandler<TransferFunds>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IClock _clock;
    private readonly IMessageBroker _messageBroker;
    private readonly ILogger<TransferFundsHandler> _logger;

    public TransferFundsHandler(IWalletRepository walletRepository, IClock clock, IMessageBroker messageBroker,
        ILogger<TransferFundsHandler> logger)
    {
        _walletRepository = walletRepository;
        _clock = clock;
        _messageBroker = messageBroker;
        _logger = logger;
    }

    public async Task HandleAsync(TransferFunds command, CancellationToken cancellationToken = default)
    {
        var (fromWalletId, toWalletId, amount) = command;
        var fromWallet = await _walletRepository.GetAsync(fromWalletId);
        if (fromWallet is null)
        {
            throw new WalletNotFoundException(fromWalletId);
        }

        var toWallet = await _walletRepository.GetAsync(toWalletId);
        if (toWallet is null)
        {
            throw new WalletNotFoundException(toWalletId);
        }

        var now = _clock.CurrentDate();
        var currency = fromWallet.Currency;
        fromWallet.TransferFunds(toWallet, amount, now);
        await _walletRepository.UpdateAsync(fromWallet);
        await _walletRepository.UpdateAsync(toWallet);
        await _messageBroker.PublishAsync(new FundsTransferred(fromWalletId, toWalletId, amount, currency),
            cancellationToken);
        _logger.LogInformation($"Transferred {amount} {currency} from: '{fromWallet.Id}' to: '{toWallet.Id}'.");
    }
}