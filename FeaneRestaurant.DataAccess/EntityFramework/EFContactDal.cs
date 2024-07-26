using FeaneRestaurant.DataAccess.Abstract;
using FeaneRestaurant.DataAccess.Concrete;
using FeaneRestaurant.DataAccess.Repositories;
using FeaneRestaurant.Entities.Entites;

namespace FeaneRestaurant.DataAccess.EntityFramework
{
    public class EFContactDal : GenericRepository<Contact>, IContactDal
    {
        public EFContactDal(AppDbContext context) : base(context)
        {
        }
    }
}
