using FeaneRestaurant.Dto.ProductDto;
using FeaneRestaurant.Entities.Entites;

namespace FeaneRestaurant.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        //List<Product> GetProductsWithCategories();
    }
}
