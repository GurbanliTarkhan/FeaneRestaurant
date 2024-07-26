using AutoMapper;
using FeaneRestaurant.Business.Abstract;
using FeaneRestaurant.Dto.SocialMediaDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.TGetAll();
            var result = _mapper.Map<IEnumerable<ResultSocialMediaDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult SocialMediaGet(int id)
        {
            var value = _socialMediaService.TGetById(id);
            if (value == null)
            {
                return NotFound("SocialMedia not found");
            }
            var result = _mapper.Map<ResultSocialMediaDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMedia SocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(SocialMediaDto);
            _socialMediaService.TAdd(value);
            return Ok("SocialMedia successfully added");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto SocialMediaDto)
        {
            var existSocialMedia = _socialMediaService.TGetById(SocialMediaDto.SocialMediaID);
            if (existSocialMedia == null)
            {
                return NotFound("SocialMedia not found");
            }
            var result = _mapper.Map(SocialMediaDto, existSocialMedia);
            _socialMediaService.TUpdate(result);
            return Ok("SocialMedia successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var existSocialMedia = _socialMediaService.TGetById(id);
            if (existSocialMedia == null)
            {
                return NotFound("SocialMedia not found");
            }
            _socialMediaService.TRemove(existSocialMedia);
            return Ok("SocialMedia successfully deleted");
        }
    }
}
