using FeaneRestaurant.DataAccess.Abstract;
using FeaneRestaurant.DataAccess.Concrete;
using FeaneRestaurant.DataAccess.Repositories;
using FeaneRestaurant.Dto.ProductDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.EntityFrameworkCore;

namespace FeaneRestaurant.DataAccess.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly AppDbContext _context;
        public EFProductDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //public List<Product> GetProductsWithCategories()
        //{
        //    var values = _context.Products
        //        .Include(x => x.Category)
        //        .Select(y => new ResultProductWithCategoryDto
        //        {
        //            Description = y.Description,
        //            ImageUrl = y.ImageUrl,
        //            Price = y.Price,
        //            ProductID = y.ProductID,
        //            ProductName = y.ProductName,
        //            ProductStatus = y.ProductStatus,
        //            CategoryName = y.Description
        //        }).ToList();
        //    return values;
        //}
    }
}
