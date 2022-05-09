using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateCommentsFileDTO
    {
        public IFormFile File { get; set; }
        public long CommentsId { get; set; }
    }
}
