using FTraders.Application.Notifications.Models;
using System.Threading.Tasks;

namespace FTraders.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
