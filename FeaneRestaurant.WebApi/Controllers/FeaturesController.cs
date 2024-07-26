using AutoMapper;
using FeaneRestaurant.Business.Abstract;
using FeaneRestaurant.Dto.FeatureDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.TGetAll();
            var result = _mapper.Map<IEnumerable<ResultFeatureDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult FeatureGet(int id)
        {
            var value = _featureService.TGetById(id);
            if (value == null)
            {
                return NotFound("Feature not found");
            }
            var result = _mapper.Map<ResultFeatureDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto FeatureDto)
        {
            var value = _mapper.Map<Feature>(FeatureDto);
            _featureService.TAdd(value);
            return Ok("Feature successfully added");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto FeatureDto)
        {
            var existFeature = _featureService.TGetById(FeatureDto.FeatureID);
            if (existFeature == null)
            {
                return NotFound("Feature not found");
            }
            var result = _mapper.Map(FeatureDto, existFeature);
            _featureService.TUpdate(result);
            return Ok("Feature successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var existFeature = _featureService.TGetById(id);
            if (existFeature == null)
            {
                return NotFound("Feature not found");
            }
            _featureService.TRemove(existFeature);
            return Ok("Feature successfully deleted");
        }
    }
}
