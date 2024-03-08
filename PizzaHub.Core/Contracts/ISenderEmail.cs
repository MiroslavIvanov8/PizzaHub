namespace PizzaHub.Core.Contracts
{
    public interface ISenderEmail
    {
        Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml = false);
    }
}