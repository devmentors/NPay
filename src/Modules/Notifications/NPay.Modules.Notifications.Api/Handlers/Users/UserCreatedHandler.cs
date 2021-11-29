﻿using System.Threading;
using System.Threading.Tasks;
using NPay.Modules.Notifications.Api.ExternalEvents;
using NPay.Modules.Notifications.Api.Services;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Api.Handlers.Users
{
    internal sealed class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly IEmailSender _emailSender;

        public UserCreatedHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task HandleAsync(UserCreated @event, CancellationToken cancellationToken = default)
            => _emailSender.SendAsync(@event.Email, "account_created");
    }
}