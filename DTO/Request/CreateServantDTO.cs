using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateServantDTO
    {
        public string Name { get; set; }
        public ServantType ServantType { get; set; }
        public int Duration { get; set; }
    }
}
