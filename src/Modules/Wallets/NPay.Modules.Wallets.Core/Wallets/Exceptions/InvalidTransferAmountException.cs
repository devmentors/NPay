using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class InvalidTransferAmountException : NPayException
{
    public decimal Amount { get; }

    public InvalidTransferAmountException(decimal amount) : base($"Transfer has invalid amount: '{amount}'.")
    {
        Amount = amount;
    }
}