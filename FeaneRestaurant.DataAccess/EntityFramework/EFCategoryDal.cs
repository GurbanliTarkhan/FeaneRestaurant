using FeaneRestaurant.DataAccess.Abstract;
using FeaneRestaurant.DataAccess.Concrete;
using FeaneRestaurant.DataAccess.Repositories;
using FeaneRestaurant.Entities.Entites;

namespace FeaneRestaurant.DataAccess.EntityFramework
{
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(AppDbContext context) : base(context)
        {
        }
    }
}
