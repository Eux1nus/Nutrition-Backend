using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserServant : Entity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long ServantId { get; set; }
        public Servant Servant { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsActivated { get; set; }
        public bool IsSkypePayed { get; set; }
    }
}