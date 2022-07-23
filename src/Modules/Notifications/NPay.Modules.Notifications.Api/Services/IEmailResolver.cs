using System;

namespace NPay.Modules.Notifications.Api.Services;

internal interface IEmailResolver
{
    string GetForOwner(Guid ownerId);
}