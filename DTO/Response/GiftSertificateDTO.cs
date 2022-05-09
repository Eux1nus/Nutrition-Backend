using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class GiftSertificateDTO
    {
        public long Id { get; set; }
        public int Price { get; set; }

        public GiftSertificateDTO() { }

        public GiftSertificateDTO(GiftSertificate person)
        {
            if (person == null)
                return;
            Price = person.Price;
            Id = person.Id;
        }
    }
}
