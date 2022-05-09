using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateGiftSertificateDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
