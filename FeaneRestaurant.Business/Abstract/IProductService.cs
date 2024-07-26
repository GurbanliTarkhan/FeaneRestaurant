using FeaneRestaurant.Dto.ProductDto;
using FeaneRestaurant.Entities.Entites;

namespace FeaneRestaurant.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        //List<Product> TGetProductsWithCategories();
    }
}
