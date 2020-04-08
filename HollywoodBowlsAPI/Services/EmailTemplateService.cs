using HollywoodBowlsAPI.Entities;
using System;
using System.IO;
using System.Text;

namespace HollywoodBowlsAPI.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        public string PopulateCustomerTemplate(Customer customer)
        {
            StringBuilder body = new StringBuilder();

            using (StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "MailTemplates/CustomerTemplate.html")))
            {
                body.Append(reader.ReadToEnd());
            }

            body.Replace("{FirstName}", customer.FirstName);
            body.Replace("{LastName}", customer.LastName);

            return body.ToString();
        }

        public string PopulateRestroomOrderTemplate(RestroomFormModel model)
        {
            StringBuilder body = new StringBuilder();

            using (StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "MailTemplates/RestroomOrderTemplate.html")))
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
            body.Replace("{Additional}", model.Additional);

            return body.ToString();
        }

        public string PopulateWasteOrderTemplate(WasteFormModel model)
        {
            StringBuilder body = new StringBuilder();

            using (StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "MailTemplates/WasteOrderTemplate.html")))
            {
                body.Append(reader.ReadToEnd());
            }

            body.Replace("{Company}", model.Company);
            body.Replace("{FirstName}", model.FirstName);
            body.Replace("{LastName}", model.LastName);
            body.Replace("{Email}", model.Email);
            body.Replace("{Phone}", model.Phone);
            body.Replace("{Address}", model.Address);
            body.Replace("{City}", model.City);
            body.Replace("{State}", model.State);
            body.Replace("{PostalCode}", model.PostalCode);
            body.Replace("{Country}", model.Country);
            body.Replace("{Phrase}", model.Phrase);
            body.Replace("{LocationType}", model.LocationType);
            body.Replace("{PickupDate}", model.PickupDate);
            body.Replace("{PickupTime}", model.PickupTime);
            body.Replace("{Aditional}", model.Additional);

            if(model.LocationsArray.Count == 0)
            {
                body.Replace("{Locations}", "No");
            }
            else
            {
                for(int i = 0; i < model.LocationsArray.Count; i++)
                {
                    body.Replace("{Locations}", LoopAdditionalLocations(model));
                }
            }
              



            return body.ToString();
        }

        private string LoopAdditionalLocations(WasteFormModel model)
        {

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < model.LocationsArray.Count; i++)
            {

                sb.Append($"Location { i + 2 }:" +
                $"Address: <b>{model.LocationsArray[i].Address}</b><br />" +
                $"City: <b>{model.LocationsArray[i].City}</b><br />" +
                $"State: <b>{model.LocationsArray[i].State}</b><br />" +
                $"Postal code: <b>{model.LocationsArray[i].PostalCode}</b><br />" +
                $"Country: <b>{model.LocationsArray[i].Country}</b><br />" +
                $"Pickup date: <b>{model.LocationsArray[i].PickupDate}</b><br />" +
                $"Pickup time: <b>{model.LocationsArray[i].PickupTime}</b><br />" +
                $"Schedule phrase: <b>{model.LocationsArray[i].Phrase}</b><br />" +
                $"Location type: <b>{model.LocationsArray[i].LocationType}</b><br />" +
                $"Additional info: <b>{model.LocationsArray[i].Additional}</b><br />" +
                $"<br />"


                );
            }

            return sb.ToString();
        }
    }

    
}
