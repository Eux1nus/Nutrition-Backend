using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class CommentsFileDTO
    {
        public string File { get; set; }
        public long CommentsId { get; set; }
        public long UserId { get; set; }

        public CommentsFileDTO() { }

        public CommentsFileDTO(CommentsFile commentsFile)
        {
            if (commentsFile == null)
                return;

            File = commentsFile.File;
            CommentsId = commentsFile.Comments.Id;
            UserId = commentsFile.FromUser.Id;
        }
    }
}
