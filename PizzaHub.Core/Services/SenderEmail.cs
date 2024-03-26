using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using PizzaHub.Core.Contracts;

namespace PizzaHub.Core.Services
{
    public class SenderEmail : ISenderEmail
    {
        private readonly IConfiguration _configuration;

        public SenderEmail(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml = false)
        {
            try
            {
                string mailServer = _configuration["EmailSettings:MailServer"];
                string fromEmail = _configuration["EmailSettings:FromEmail"];
                string password = _configuration["EmailSettings:Password"];
                int port = int.Parse(_configuration["EmailSettings:MailPort"]);

                var client = new SmtpClient(mailServer, port);

                client.UseDefaultCredentials = false;

                client.Credentials = new NetworkCredential(fromEmail, password);
                client.EnableSsl = true;

                var mailMessage = new MailMessage(fromEmail, toEmail, subject, body);

                mailMessage.IsBodyHtml = isBodyHtml;
                await Task.Run(() => client.Send(mailMessage));


            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw; // Rethrow the exception to propagate it
            }
        }
    }
}