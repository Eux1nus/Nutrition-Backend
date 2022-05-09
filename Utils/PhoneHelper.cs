using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils
{
    public class PhoneHelper
    {
        public static string Clear(string phoneNumber)
        {
            var regex = new Regex(@"[^\d^]");

            var result = regex.Replace(phoneNumber, "");

            return result;
        }
    }
}
