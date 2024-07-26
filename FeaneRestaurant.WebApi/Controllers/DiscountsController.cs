using AutoMapper;
using FeaneRestaurant.Business.Abstract;
using FeaneRestaurant.Dto.DiscountDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _discountService.TGetAll();
            var result = _mapper.Map<IEnumerable<ResultDiscountDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult DiscountGet(int id)
        {
            var value = _discountService.TGetById(id);
            if (value == null)
            {
                return NotFound("Discount not found");
            }
            var result = _mapper.Map<ResultDiscountDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto DiscountDto)
        {
            var value = _mapper.Map<Discount>(DiscountDto);
            _discountService.TAdd(value);
            return Ok("Discount successfully added");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto DiscountDto)
        {
            var existDiscount = _discountService.TGetById(DiscountDto.DiscountID);
            if (existDiscount == null)
            {
                return NotFound("Discount not found");
            }
            var result = _mapper.Map(DiscountDto, existDiscount);
            _discountService.TUpdate(result);
            return Ok("Discount successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var existDiscount = _discountService.TGetById(id);
            if (existDiscount == null)
            {
                return NotFound("Discount not found");
            }
            _discountService.TRemove(existDiscount);
            return Ok("Discount successfully deleted");
        }
    }
}
