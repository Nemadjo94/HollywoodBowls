using System.Threading.Tasks;
using HollywoodBowlsAPI.Entities;
using HollywoodBowlsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodBowlsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;

        public MailController(IEmailService emailService, IEmailTemplateService emailTemplateService)
        {
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
        }

        [HttpPost("sendmail")]
        public async Task<IActionResult> SendMail([FromBody]FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Model not valid: {ModelState}" );
            }

            var sendToCustomer = new MailModel()
            {
                Email = model.Email,
                Subject = "Your Hollywood Bowls order",
                HtmlTemplate = _emailTemplateService.PopulateCustomerTemplateBody(model.FirstName, model.LastName).ToString()
            };

            var sendToOwner = new MailModel()
            {
                Email = "dnn.development.server@gmail.com",
                Subject = $"Order from {model.FirstName} {model.LastName}",
                HtmlTemplate = _emailTemplateService.PopulateOwnerTemplateBody(model).ToString()
            };


            var sentToCustomer = await _emailService.SendMail(sendToCustomer);
            var sentToOwner = await _emailService.SendMail(sendToOwner);

            if (sentToCustomer && sentToOwner)
            {
                return Ok();
            }

            return StatusCode(500, "Mail could not be sent");
        }

    }
}