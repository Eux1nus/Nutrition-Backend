using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class AdditionalOptionsDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AdditionalOptionsDTO() { }

        public AdditionalOptionsDTO(AdditionalOptions additional)
        {
            if (additional == null)
                return;

            Id = additional.Id;
            Name = additional.Name;

        }
    }
}
