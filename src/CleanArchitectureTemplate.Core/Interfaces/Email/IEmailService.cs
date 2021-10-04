using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string toName, string subject, string message);
    }
}
