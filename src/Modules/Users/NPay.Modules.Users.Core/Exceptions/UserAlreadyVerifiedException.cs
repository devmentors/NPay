using System;
using NPay.Shared.Exceptions;

namespace NPay.Modules.Users.Core.Exceptions;

internal sealed class UserAlreadyVerifiedException : NPayException
{
    public Guid UserId { get; }

    public UserAlreadyVerifiedException(Guid userId) : base($"User with ID: '{userId}' is already verified.")
    {
        UserId = userId;
    }
}