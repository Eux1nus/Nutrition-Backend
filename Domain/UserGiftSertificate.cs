using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserGiftSertificate : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public long UserId { get; set; }
        public User User { get; set; }
        public long GiftSertificateId { get; set; }
        public GiftSertificate GiftSertificate { get; set; }
    }
}
