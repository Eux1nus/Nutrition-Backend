using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Questions : Entity
    {
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public long FromUserId { get; set; }
        public User FromUser { get; set; }

        public long ToUserId { get; set; }
        public User ToUser { get; set; }
    }
}
