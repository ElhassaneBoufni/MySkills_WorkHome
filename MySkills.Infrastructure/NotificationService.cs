using MySkills.Application.Interfaces;
using MySkills.Application.Notifications.Models;
using System.Threading.Tasks;

namespace MySkills.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
