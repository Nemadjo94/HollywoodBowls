using System;
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

        [HttpPost("restroomOrder")]
        public async Task<IActionResult> PostRestroomOrder([FromBody]RestroomFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Model not valid: {ModelState}");
            }
            try
            {

                await Task.Run(() =>
                {
                    var customer = new Customer()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };

                    var sendToCustomer = new MailModel()
                    {
                        Email = model.Email,
                        Subject = "Your Hollywood Bowls order",
                        HtmlTemplate = _emailTemplateService.PopulateCustomerTemplate(customer)
                    };

                    var sendToOwner = new MailModel()
                    {
                        //Email = "dnn.development.server@gmail.com",
                        Email = "nemadjo94@gmail.com",
                        Subject = $"Order from {model.FirstName} {model.LastName}",
                        HtmlTemplate = _emailTemplateService.PopulateRestroomOrderTemplate(model)
                    };


                    _emailService.SendMail(sendToCustomer);
                    _emailService.SendMail(sendToOwner);
                });

                return Ok();

            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }


        }

        [HttpPost("wasteOrder")]
        public async Task<IActionResult> PostWasteOrder([FromBody]WasteFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Model not valid: {ModelState}");
            }
            try
            {

                await Task.Run(() =>
                {
                    var customer = new Customer()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };

                    var sendToCustomer = new MailModel()
                    {
                        Email = model.Email,
                        Subject = "Your Hollywood Bowls order",
                        HtmlTemplate = _emailTemplateService.PopulateCustomerTemplate(customer)
                    };

                    var sendToOwner = new MailModel()
                    {
                        //Email = "dnn.development.server@gmail.com",
                        Email = "nemadjo94@gmail.com",
                        Subject = $"Order from {model.FirstName} {model.LastName}",
                        HtmlTemplate = _emailTemplateService.PopulateWasteOrderTemplate(model)
                    };


                    _emailService.SendMail(sendToCustomer);
                    _emailService.SendMail(sendToOwner);
                });

                return Ok();

            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

    } 

}
