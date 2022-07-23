using NPay.Shared.Commands;

namespace NPay.Modules.Wallets.Application.Owners.Commands;

public record AddOwner(string Email) : ICommand;