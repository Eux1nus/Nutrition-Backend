using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class CommentsDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public CommentsDTO() { }

        public CommentsDTO(Comments comments)
        {
            if (comments == null)
                return;

            Id = comments.Id;
            UserId = comments.FromUserId;
            Description = comments.Description;
            Name = comments.FromUser.Person.Name;
            CreateDate = comments.CreateDate;
        }
    }
}
