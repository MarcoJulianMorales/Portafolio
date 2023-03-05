using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Services
{
    public interface IEmailService
    {
        Task send(ContactDTO contact);
    }
    public class EmailSendGridService: IEmailService
    {
        private readonly IConfiguration configuration;
        
        public EmailSendGridService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task send(ContactDTO contact)
        {
            var apikey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var name = configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(apikey);
            var from = new EmailAddress(email, name);
            var subject = $"The customer {contact.Email} wants to contact you";
            var to = new EmailAddress(email, name);
            var plainTextMesssage = contact.Message;
            var htmldData = $@"From: {contact.Name} -
            Email: {contact.Email}
            Message: {contact.Message}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, plainTextMesssage, htmldData);
            var response = await client.SendEmailAsync(singleEmail);
        }
    }
}
