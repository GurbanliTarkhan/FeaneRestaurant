using AutoMapper;
using FeaneRestaurant.Business.Abstract;
using FeaneRestaurant.Dto.AboutDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetAll();
            var result = _mapper.Map<IEnumerable<ResultAboutDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult AboutGet(int id)
        {
            var value = _aboutService.TGetById(id);
            if (value == null)
            {
                return NotFound("About not found");
            }
            var result = _mapper.Map<ResultAboutDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto aboutDto)
        {
            var value = _mapper.Map<About>(aboutDto);
            _aboutService.TAdd(value);
            return Ok("About successfully added");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto aboutDto)
        {
            var existAbout = _aboutService.TGetById(aboutDto.AboutID);
            if (existAbout == null)
            {
                return NotFound("About not found");
            }
            var result = _mapper.Map(aboutDto, existAbout);
            _aboutService.TUpdate(result);
            return Ok("About successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var existAbout = _aboutService.TGetById(id);
            if (existAbout == null)
            {
                return NotFound("About not found");
            }
            _aboutService.TRemove(existAbout);
            return Ok("About successfully deleted");
        }
    }
}
