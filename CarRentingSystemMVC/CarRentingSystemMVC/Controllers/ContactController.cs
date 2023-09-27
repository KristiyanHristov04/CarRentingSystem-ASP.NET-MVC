using CarRentingSystemMVC.APIs;
using CarRentingSystemMVC.Models.Car;
using Microsoft.AspNetCore.Mvc;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;

namespace CarRentingSystemMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactFormModel contactFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(contactFormModel);
            }

            string apiKey = APIKeys.EmailServiceAPIKey;

            Configuration.Default.ApiKey["api-key"] = apiKey;

            var apiInstance = new TransactionalEmailsApi();

            string SenderName = "user";
            string SenderEmail = contactFormModel.EmailAddress;
            SendSmtpEmailSender emailSender = new SendSmtpEmailSender(SenderName, SenderEmail);

            string ToEmail = "merlin_burgera@abv.bg";
            string ToName = "Kristiyan Hristov";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);

            string HtmlContent = null;
            string TextContent = contactFormModel.Message;
            string Subject = contactFormModel.Subject;

            try
            {
                var sendSmtpEmail = new SendSmtpEmail(emailSender, To, null, null, HtmlContent, TextContent, Subject);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View("ThankYou");
        }
    }
}
