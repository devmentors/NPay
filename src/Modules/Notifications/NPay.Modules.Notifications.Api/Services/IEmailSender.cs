using System.Threading.Tasks;

namespace NPay.Modules.Notifications.Api.Services;

internal interface IEmailSender
{
    Task SendAsync(string receiver, string template);
}