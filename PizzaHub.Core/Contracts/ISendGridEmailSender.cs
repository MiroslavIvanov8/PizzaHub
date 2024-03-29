namespace PizzaHub.Core.Contracts
{
    public interface ISendGridEmailSender
    {
        Task SendEmailAsync(
            string fromEmail,
            string fromName,
            string toEmail,
            string subject,
            string htmlContent);
    }
}