using AutoMapper;
using FeaneRestaurant.Business.Abstract;
using FeaneRestaurant.Dto.ProductDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetAll();
            var result = _mapper.Map<IEnumerable<ResultProductDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult ProductGet(int id)
        {
            var value = _productService.TGetById(id);
            if (value == null)
            {
                return NotFound("Product not found");
            }
            var result = _mapper.Map<ResultProductDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto ProductDto)
        {
            var value = _mapper.Map<Product>(ProductDto);
            _productService.TAdd(value);
            return Ok("Product successfully added");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto ProductDto)
        {
            var existProduct = _productService.TGetById(ProductDto.ProductID);
            if (existProduct == null)
            {
                return NotFound("Product not found");
            }
            var result = _mapper.Map(ProductDto, existProduct);
            _productService.TUpdate(result);
            return Ok("Product successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existProduct = _productService.TGetById(id);
            if (existProduct == null)
            {
                return NotFound("Product not found");
            }
            _productService.TRemove(existProduct);
            return Ok("Product successfully deleted");
        }
    }
}
