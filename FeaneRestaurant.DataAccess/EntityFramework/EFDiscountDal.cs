using FeaneRestaurant.DataAccess.Abstract;
using FeaneRestaurant.DataAccess.Concrete;
using FeaneRestaurant.DataAccess.Repositories;
using FeaneRestaurant.Entities.Entites;

namespace FeaneRestaurant.DataAccess.EntityFramework
{
    public class EFDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EFDiscountDal(AppDbContext context) : base(context)
        {
        }
    }
}
