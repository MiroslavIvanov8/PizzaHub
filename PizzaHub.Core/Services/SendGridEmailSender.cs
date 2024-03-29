namespace PizzaHub.Core.Services
{
    using SendGrid;
    using SendGrid.Helpers.Mail;

    using Contracts;

    public class SendGridEmailSender : ISendGridEmailSender
    {
        private readonly string _apiKey;

        public SendGridEmailSender(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task SendEmailAsync(
            string fromEmail,
            string fromName,
            string toEmail,
            string subject,
            string htmlContent)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(fromEmail, fromName);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}