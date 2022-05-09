using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class QuestionsRepository : Repository<Questions>, IQuestionsRepository
    {
        public QuestionsRepository(AppDBContext context) : base(context)
        {
        }
    }
}
