using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NPay.Modules.Users.Shared.Events;
using NPay.Modules.Wallets.Core.Owners.Exceptions;
using NPay.Modules.Wallets.Core.Owners.Repositories;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Events;
using NPay.Shared.Messaging;
using NPay.Shared.Time;

namespace NPay.Modules.Wallets.Application.Owners.ExternalEvents.Handlers;

internal sealed class UserVerifiedHandler : IEventHandler<UserVerified>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMessageBroker _messageBroker;
    private readonly IClock _clock;
    private readonly ILogger<UserVerifiedHandler> _logger;

    public UserVerifiedHandler(IOwnerRepository ownerRepository, IMessageBroker messageBroker, IClock clock,
        ILogger<UserVerifiedHandler> logger)
    {
        _ownerRepository = ownerRepository;
        _messageBroker = messageBroker;
        _clock = clock;
        _logger = logger;
    }
        
    public async Task HandleAsync(UserVerified @event, CancellationToken cancellationToken = default)
    {
        var owner = await _ownerRepository.GetAsync(@event.UserId);
        if (owner is null)
        {
            throw new OwnerNotFoundException(@event.UserId);
        }

        var now = _clock.CurrentDate();
        owner.Verify(now);
        await _ownerRepository.UpdateAsync(owner);
        await _messageBroker.PublishAsync(new OwnerVerified(owner.Id), cancellationToken);
        _logger.LogInformation($"Verified an owner for the user with ID: '{@event.UserId}'.");
    }
}