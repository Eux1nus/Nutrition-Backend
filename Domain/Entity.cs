using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Entity
    {
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DateDelete { get; set; }
        public long Id { get; set; }
    }
}
