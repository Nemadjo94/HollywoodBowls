using HollywoodBowlsAPI.Entities;
using System.Threading.Tasks;

namespace HollywoodBowlsAPI.Services
{
    public interface IEmailService
    {
        Task SendMail(MailModel model);
    }
}
