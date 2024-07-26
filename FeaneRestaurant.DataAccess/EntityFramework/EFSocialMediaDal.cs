using FeaneRestaurant.DataAccess.Abstract;
using FeaneRestaurant.DataAccess.Concrete;
using FeaneRestaurant.DataAccess.Repositories;
using FeaneRestaurant.Entities.Entites;

namespace FeaneRestaurant.DataAccess.EntityFramework
{
    public class EFSocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        public EFSocialMediaDal(AppDbContext context) : base(context)
        {
        }
    }
}
