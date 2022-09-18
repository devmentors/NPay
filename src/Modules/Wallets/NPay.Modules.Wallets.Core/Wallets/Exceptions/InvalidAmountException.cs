using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Core.Wallets.Exceptions;

internal sealed class InvalidAmountException : NPayException
{
    public decimal Amount { get; }

    public InvalidAmountException(decimal amount) : base($"Amount: '{amount}' is invalid.")
    {
        Amount = amount;
    }
}