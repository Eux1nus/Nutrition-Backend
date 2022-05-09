using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class UserAdditionalOptionsDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public UserAdditionalOptionsDTO() { }

        public UserAdditionalOptionsDTO(UserAdditionalOptions additional)
        {
            if (additional == null)
                return;

            Id = additional.Id;
            Name = additional.User.Person.Name;
        }
    }
}
