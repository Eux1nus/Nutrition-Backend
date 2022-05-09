using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Email
{
    public interface IEmailService
    {
        Task<bool> SendMessage(string receiver, string subject, string text);
    }
}
