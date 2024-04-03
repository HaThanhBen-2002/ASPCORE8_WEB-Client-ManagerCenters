using ManagementService.Models;

namespace ManagementService.Services.Interfaces
{
    public interface IEmailService
    {
        string SendEmail(Message message);
    }
}
