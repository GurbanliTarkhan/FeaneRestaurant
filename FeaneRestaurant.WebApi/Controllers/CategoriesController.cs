using AutoMapper;
using FeaneRestaurant.Business.Abstract;
using FeaneRestaurant.Dto.CategoryDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            var result = _mapper.Map<IEnumerable<ResultCategoryDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value == null)
            {
                return NotFound("Category not found");
            }
            var result = _mapper.Map<ResultCategoryDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto CategoryDto)
        {
            var value = _mapper.Map<Category>(CategoryDto);
            _categoryService.TAdd(value);
            return Ok("Category successfully added");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto CategoryDto)
        {
            var existCategory = _categoryService.TGetById(CategoryDto.CategoryID);
            if (existCategory == null)
            {
                return NotFound("Category not found");
            }
            var result = _mapper.Map(CategoryDto, existCategory);
            _categoryService.TUpdate(result);
            return Ok("Category successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var existCategory = _categoryService.TGetById(id);
            if (existCategory == null)
            {
                return NotFound("Category not found");
            }
            _categoryService.TRemove(existCategory);
            return Ok("Category successfully deleted");
        }
    }
}
