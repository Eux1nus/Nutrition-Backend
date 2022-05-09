using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class QuestionsPhotoRepository : Repository<QuestionsPhoto>, IQuestionsPhotoRepository
    {
        public QuestionsPhotoRepository(AppDBContext context) : base(context)
        {

        }
    }
}
