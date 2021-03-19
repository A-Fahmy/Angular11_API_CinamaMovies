using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularToAPI.Services
{
    public static class SendGridAPI
    {
        public static async Task<bool> Execute(string userEmail, string userName, string plainTextContent,
            string htmlContent, string subject)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("Rouby82@gmail.com", "ahmed_Fahmy1982@yahoo.com");
            var to = new EmailAddress(userEmail, userName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return await Task.FromResult(true);
        }
    }
}
