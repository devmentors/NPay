using System.Threading.Tasks;

namespace NPay.Modules.Notifications.Shared;

public interface INotificationsModuleApi
{
    Task SendEmailAsync(string receiver, string template);
}