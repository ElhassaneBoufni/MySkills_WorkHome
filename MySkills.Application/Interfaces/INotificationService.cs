using MySkills.Application.Notifications.Models;
using System.Threading.Tasks;

namespace MySkills.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
