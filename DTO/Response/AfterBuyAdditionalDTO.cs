using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class AfterBuyAdditionalDTO
    {
        public long Id { get; set; }
        public AfterBuyAdditionalDTO() { }

        public AfterBuyAdditionalDTO(AfterBuyAdditionalServant afterBuyadditional)
        {
            if (afterBuyadditional == null)
                return;

            Id = afterBuyadditional.Id;
        }
    }
}
