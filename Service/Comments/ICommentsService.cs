using Domain;
using DTO.Request;
using DTO.Response;

using System.Threading.Tasks;

namespace Services.Comments
{
    public interface ICommentsService
    {
        Task<CommentsDTO> CreateComments(CreateCommentsDTO request, User user);
        Task DeleteComments(long commentId, User user);
        Task<CommentsDTO[]> GetComments(long reviewId);
    }
}
