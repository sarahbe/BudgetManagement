using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace BudgetManagement.Services
{
    //IIdentityMessageService: interface can be used to configure your service to send emails or SMS messages,
    // we need to implement our email or SMS Service in method “SendAsync”.

    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }


        private async Task configSendGridasync(IdentityMessage message)
        {
            var apiKey = Environment.GetEnvironmentVariable("Budget" , EnvironmentVariableTarget.User);
            var client = new SendGridClient(apiKey);
            var emailFrom = new EmailAddress("sarah.beirkdar@gmail.com", "Sarah Beirkdar");
            var emailTo = new EmailAddress(message.Destination,message.Destination);
            var msg = MailHelper.CreateSingleEmail(emailFrom,emailTo , message.Subject,message.Body, message.Body);
            var response = await client.SendEmailAsync(msg);        
        }
    }
}