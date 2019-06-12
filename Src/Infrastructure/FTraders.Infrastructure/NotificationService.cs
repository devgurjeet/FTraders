using System.Threading.Tasks;
using FTraders.Application.Interfaces;
using FTraders.Application.Notifications.Models;

namespace FTraders.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
