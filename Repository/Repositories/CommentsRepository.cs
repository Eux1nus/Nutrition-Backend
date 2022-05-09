using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class CommentsRepository : Repository<Comments>, ICommentsRepository
    {
        public CommentsRepository(AppDBContext context) : base(context)
        {

        }
    }
}
