using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace NPay.Modules.Notifications.Api.Services;

internal sealed class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(ILogger<EmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendAsync(string receiver, string template)
    {
        // TODO: Implement an email sender
        _logger.LogInformation($"Sending an email to: '{receiver}', template: '{template}'...");
        return Task.CompletedTask;
    }
}