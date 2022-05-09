using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CommentsFile : Entity
    {
        public string File { get; set; }
        public long FromUserId { get; set; }
        public User FromUser { get; set; }

        public DateTime CreateDate { get; set; }

        public long CommentsId { get; set; }
        public Comments Comments { get; set; }
    }
}
