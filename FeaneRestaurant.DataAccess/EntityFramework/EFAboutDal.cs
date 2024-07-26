using FeaneRestaurant.DataAccess.Abstract;
using FeaneRestaurant.DataAccess.Concrete;
using FeaneRestaurant.DataAccess.Repositories;
using FeaneRestaurant.Entities.Entites;

namespace FeaneRestaurant.DataAccess.EntityFramework
{
    public class EFAboutDal : GenericRepository<About>, IAboutDal
    {
        public EFAboutDal(AppDbContext context) : base(context)
        {
        }
    }
}
