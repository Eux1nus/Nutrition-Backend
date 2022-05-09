using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class ServantDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public bool IsActivated { get; set; }
        public ServantDTO() { }

        public ServantDTO(Servant servant)
        {
            if (servant == null)
                return;

            Id = servant.Id;
            Name = servant.Name;
            TimeStart = servant.TimeStart;
            TimeEnd = servant.TimeEnd;
            IsActivated = servant.IsActivated;
            
        }
    }
}
