using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Utils
{
    public static class SMTPHelper
    {
        public readonly static string SMTP_SERVER;
        public readonly static int SMTP_PORT;
        public readonly static string SMTP_LOGIN;
        public readonly static string SMTP_PASSWORD;
        static SMTPHelper()
        {
            using (var r = new StreamReader("mailsettings.json"))
            {
                var json = r.ReadToEnd();
                dynamic d = JObject.Parse(json);

                SMTP_SERVER = d.SMTP_SERVER;
                SMTP_PORT = d.SMTP_PORT;
                SMTP_LOGIN = d.SMTP_LOGIN;
                SMTP_PASSWORD = d.SMTP_PASSWORD;
            }

        }

        public static async Task<bool> SendMail(SendMailModel model)

        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(SMTP_LOGIN, "Nutrition");
            mail.To.Add(new MailAddress(model.MailTo));
            mail.Subject = model.Subject;
            mail.IsBodyHtml = true;
            mail.Body = model.Message;

            SmtpClient client = new SmtpClient(SMTP_SERVER, SMTP_PORT);

            client.UseDefaultCredentials = false;
            client.EnableSsl = true;

            var crd = new NetworkCredential(SMTP_LOGIN, SMTP_PASSWORD);
            client.Credentials = crd;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            await client.SendMailAsync(mail);
            mail.Dispose();
            return true;
        }

        static Regex ValidEmailRegex = CreateValidEmailRegex();


        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        public static bool EmailIsValid(string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }


        public class SendMailModel
        {
            public string MailTo { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; }
        }
    }
}