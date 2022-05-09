using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class QuestionnaireRepository : Repository<Questionnaire>, IQuestionnaireRepository
    {
        public QuestionnaireRepository(AppDBContext context) : base(context)
        {

        }
    }
}
