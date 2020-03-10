using HollywoodBowlsAPI.Entities;
using System.Text;

namespace HollywoodBowlsAPI.Services
{
    public interface IEmailTemplateService
    {
        StringBuilder PopulateCustomerTemplateBody(string firstName, string lastName);
        StringBuilder PopulateOwnerTemplateBody(FormModel model);
    }
}