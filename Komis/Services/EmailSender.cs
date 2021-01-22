using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Komis.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKeyIn, string subjectIn, string messageIn, string emailIn)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("KomisSamochodowy@email.com");
            var subject = subjectIn;
            var to = new EmailAddress(emailIn);
            var plainTextContent = messageIn;
            var htmlContent = messageIn;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            return client.SendEmailAsync(msg);
        }
    }
}