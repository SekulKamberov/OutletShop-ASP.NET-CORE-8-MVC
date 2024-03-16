namespace OutletShop.Utility
{
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public interface IEmailSender
    {
         Task SendEmailAsync(string email, string subject, string htmlMessage); 
    }
}
