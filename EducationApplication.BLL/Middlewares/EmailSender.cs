using Microsoft.AspNetCore.Identity;

namespace EducationApplication.BLL.Middlewares
{
    public class EmailSender : IEmailSender<IdentityUser>
    {
        public Task SendConfirmationLinkAsync(IdentityUser user, string email, string confirmationLink)
        {
            return Task.CompletedTask;
        }

        public Task SendPasswordResetLinkAsync(IdentityUser user, string email, string resetLink)
        {
            return Task.CompletedTask;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }

        public Task SendPasswordResetCodeAsync(IdentityUser user, string email, string resetCode)
        {
            throw new NotImplementedException();
        }
    }
}
