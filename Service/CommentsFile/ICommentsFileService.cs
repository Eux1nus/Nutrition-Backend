using Domain;
using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommentsFile
{
    public interface ICommentsFileService
    {
        Task<CommentsFileDTO> CreateCommentsFile(CreateCommentsFileDTO request, User user);
        Task DeleteComments(long commentsFileId, User user);
    }
}
