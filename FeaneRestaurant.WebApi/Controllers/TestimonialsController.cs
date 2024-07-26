using AutoMapper;
using FeaneRestaurant.Business.Abstract;
using FeaneRestaurant.Dto.TestimonialDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetAll();
            var result = _mapper.Map<IEnumerable<ResultTestimonialDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult TestimonialGet(int id)
        {
            var value = _testimonialService.TGetById(id);
            if (value == null)
            {
                return NotFound("Testimonial not found");
            }
            var result = _mapper.Map<ResultTestimonialDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto TestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(TestimonialDto);
            _testimonialService.TAdd(value);
            return Ok("Testimonial successfully added");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto TestimonialDto)
        {
            var existTestimonial = _testimonialService.TGetById(TestimonialDto.TestimonialID);
            if (existTestimonial == null)
            {
                return NotFound("Testimonial not found");
            }
            var result = _mapper.Map(TestimonialDto, existTestimonial);
            _testimonialService.TUpdate(result);
            return Ok("Testimonial successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var existTestimonial = _testimonialService.TGetById(id);
            if (existTestimonial == null)
            {
                return NotFound("Testimonial not found");
            }
            _testimonialService.TRemove(existTestimonial);
            return Ok("Testimonial successfully deleted");
        }
    }
}
