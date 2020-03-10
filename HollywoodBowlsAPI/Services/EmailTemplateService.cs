using HollywoodBowlsAPI.Entities;
using System;
using System.IO;
using System.Text;

namespace HollywoodBowlsAPI.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        public StringBuilder PopulateCustomerTemplateBody(string firstName, string lastName)
        {
            StringBuilder body = new StringBuilder();

            using (StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "MailTemplates/CustomerTemplate.html")))
            {
                body.Append(reader.ReadToEnd());
            }

            body.Replace("{FirstName}", firstName);
            body.Replace("{LastName}", lastName);

            return body;
        }

        public StringBuilder PopulateOwnerTemplateBody(FormModel model)
        {
            StringBuilder body = new StringBuilder();

            using (StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "MailTemplates/OwnerTemplate.html")))
            {
                body.Append(reader.ReadToEnd());
            }

            body.Replace("{Company}", model.Company);
            body.Replace("{FirstName}", model.FirstName);
            body.Replace("{LastName}", model.LastName);
            body.Replace("{Email}", model.Email);
            body.Replace("{Phone}", model.Phone);
            body.Replace("{Trailers}", model.Trailers.ToString());
            body.Replace("{DeliveryDate}", model.DeliveryDate);
            body.Replace("{DeliveryTime}", model.DeliveryTime);
            body.Replace("{Address1}", model.Address1);
            body.Replace("{Address2}", model.Address2);
            body.Replace("{City}", model.City);
            body.Replace("{State}", model.State);
            body.Replace("{PostalCode}", model.PostalCode);
            body.Replace("{Country}", model.Country);
            body.Replace("{PickupDate}", model.PickupDate);
            body.Replace("{PickupTime}", model.PickupTime);
            body.Replace("{Contact}", model.Contact);
            body.Replace("{Aditional}", model.Additional);

            return body;
        }
    }
}
