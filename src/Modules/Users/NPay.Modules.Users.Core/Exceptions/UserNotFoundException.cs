using System;
using NPay.Shared.Exceptions;

namespace NPay.Modules.Users.Core.Exceptions;

internal sealed class UserNotFoundException : NPayException
{
    public Guid UserId { get; }

    public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
    {
        UserId = userId;
    }
}