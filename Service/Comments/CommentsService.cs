using Domain;
using DTO.Request;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Comments
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository CommentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            CommentsRepository = commentsRepository;
        }

        public async Task<CommentsDTO> CreateComments(CreateCommentsDTO request, User user)
        {
            var comments = new Domain.Comments
            {
                FromUserId = user.Id,
                Description = request.Description,
                CreateDate = DateTime.Now,
                FoodDiaryId = user.Id
            };

            await CommentsRepository.CreateAsync(comments);
            await CommentsRepository.SaveChangesAsync();

            return new CommentsDTO(comments);
        }

        public async Task DeleteComments(long commentsId, User user)
        {
            var comments = await CommentsRepository
                .GetAll()
                .Where(x => x.Id == commentsId)
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(113);

            if (comments.FromUserId != user.Id)
                throw new ServiceErrorException(112);

            CommentsRepository.Delete(comments);
            await CommentsRepository.SaveChangesAsync();
        }

        public async Task<CommentsDTO[]> GetComments(long userId)
        {
            var comments = await CommentsRepository
                .GetAll()
                .AsNoTracking()
                .Include(x => x.FromUser)
                .ThenInclude(x => x.Person)
                .Where(x => x.FromUserId == userId)
                .OrderBy(x => x.CreateDate)
                .Select(x => new CommentsDTO(x))
                .ToArrayAsync();

            return comments;
        }
    }
}
