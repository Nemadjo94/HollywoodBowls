using HollywoodBowlsAPI.Entities;
using System.Text;

namespace HollywoodBowlsAPI.Services
{
    public interface IEmailTemplateService
    {
        string PopulateCustomerTemplate(Customer customer);
        string PopulateRestroomOrderTemplate(RestroomFormModel model);
        string PopulateWasteOrderTemplate(WasteFormModel model);
    }
}