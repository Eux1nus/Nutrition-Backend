using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DTO.Request
{
    public class CreatePersonDTO
    {
        //[Required]
        public string Name { get; set; }

        //[Required]
        public string SurName { get; set; }
        //[Required]
        public string PhoneNumber { get; set; }

        //[Required]
        public string Password { get; set; }

        //[Required]
        public SexType SexType { get; set; }

        //[Required]
        public DateTime DateOfBirth { get; set; }

        //[Required]
        public string Email { get; set; }

        //[Required]
        public bool AgreementIsChecked { get; set; }

    }
}
