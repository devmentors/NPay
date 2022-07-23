using System;

namespace NPay.Modules.Notifications.Api.Services;

internal sealed class EmailResolver : IEmailResolver
{
    // TODO: Resolve the user/owner email address from other modules
    public string GetForOwner(Guid ownerId) => $"{ownerId:N}@npay.io";
}