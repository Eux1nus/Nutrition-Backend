using Services.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using static Utils.SMTPHelper;

namespace Services.Mail
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendMessage(string receiver, string subject, string text)
        {
            var message = new SendMailModel
            {
                MailTo = receiver,
                Subject = subject,
                Message = text
            };
            return await SMTPHelper.SendMail(message);
        }
    }
}
