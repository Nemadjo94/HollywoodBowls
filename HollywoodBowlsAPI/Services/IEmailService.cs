using HollywoodBowlsAPI.Entities;
using System.Threading.Tasks;

namespace HollywoodBowlsAPI.Services
{
    public interface IEmailService
    {
        Task<bool> SendMail(MailModel model);
    }
}
