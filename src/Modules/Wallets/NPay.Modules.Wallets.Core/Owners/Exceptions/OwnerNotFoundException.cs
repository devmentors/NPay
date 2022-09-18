using System;
using NPay.Shared.Exceptions;

namespace NPay.Modules.Wallets.Core.Owners.Exceptions;

internal sealed class OwnerNotFoundException : NPayException
{
    public Guid OwnerId { get; }

    public OwnerNotFoundException(Guid ownerId) : base($"Owner with ID: '{ownerId}' was not found.")
    {
        OwnerId = ownerId;
    }
}