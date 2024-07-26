using AutoMapper;
using FeaneRestaurant.Business.Abstract;
using FeaneRestaurant.Dto.ContactDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetAll();
            var result = _mapper.Map<IEnumerable<ResultContactDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult ContactGet(int id)
        {
            var value = _contactService.TGetById(id);
            if (value == null)
            {
                return NotFound("Contact not found");
            }
            var result = _mapper.Map<ResultContactDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto ContactDto)
        {
            var value = _mapper.Map<Contact>(ContactDto);
            _contactService.TAdd(value);
            return Ok("Contact successfully added");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto ContactDto)
        {
            var existContact = _contactService.TGetById(ContactDto.ContactID);
            if (existContact == null)
            {
                return NotFound("Contact not found");
            }
            var result = _mapper.Map(ContactDto, existContact);
            _contactService.TUpdate(result);
            return Ok("Contact successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var existContact = _contactService.TGetById(id);
            if (existContact == null)
            {
                return NotFound("Contact not found");
            }
            _contactService.TRemove(existContact);
            return Ok("Contact successfully deleted");
        }
    }
}
