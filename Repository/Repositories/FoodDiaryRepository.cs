using Domain;
using Repository.Interfaces;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class FoodDiaryRepository : Repository<FoodDiary>, IFoodDiaryRepository
    {
        public FoodDiaryRepository(AppDBContext context) : base(context)
        {

        }
    }
}
