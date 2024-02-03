using ProductManagement.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}