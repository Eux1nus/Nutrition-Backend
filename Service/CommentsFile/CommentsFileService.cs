using Domain;
using DTO.Request;
using DTO.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommentsFile
{
    public class CommentsFileService : ICommentsFileService
    {
        private readonly ICommentsFileRepository CommentsFileRepository;
        private readonly ICommentsRepository CommentsRepository;
        private readonly IPhotoService PhotoService;
        public CommentsFileService(ICommentsFileRepository commentsFileRepository, IPhotoService photoService, ICommentsRepository commentsRepository)
        {
            CommentsFileRepository = commentsFileRepository;
            CommentsRepository = commentsRepository;
            PhotoService = photoService;
        }

        public async Task<CommentsFileDTO> CreateCommentsFile(CreateCommentsFileDTO request, User user)
        {
            var file = await PhotoService.AddPhoto(request.File);

            var comment = await CommentsRepository
                .GetAll()
                .Include(x => x.FromUser)
                .Where(x => x.Id == request.CommentsId)
                .FirstOrDefaultAsync()

                ?? throw new ServiceErrorException();

            var commentsFile = new Domain.CommentsFile
            {
                FromUserId = user.Id,
                CreateDate = DateTime.Now,
                Comments = comment,
                File = file,
            };

            await CommentsFileRepository.CreateAsync(commentsFile);
            await CommentsFileRepository.SaveChangesAsync();

            return new CommentsFileDTO(commentsFile);
        }

        public async Task DeleteComments(long commentsFileId, User user)
        {
            var commentsFile = await CommentsFileRepository
                .GetAll()
                .Where(x => x.Id == commentsFileId)
                .FirstOrDefaultAsync()
                ?? throw new ServiceErrorException(113);

            if (commentsFile.FromUserId != user.Id)
                throw new ServiceErrorException(112);

            CommentsFileRepository.Delete(commentsFile);
            await CommentsFileRepository.SaveChangesAsync();
        }
    }
}
