using AutoMapper;
using FeaneRestaurant.Business.Abstract;
using FeaneRestaurant.Dto.BookingDto;
using FeaneRestaurant.Entities.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetAll();
            var result = _mapper.Map<IEnumerable<ResultBookingDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult BookingGet(int id)
        {
            var value = _bookingService.TGetById(id);
            if (value == null)
            {
                return NotFound("Booking not found");
            }
            var result = _mapper.Map<ResultBookingDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto BookingDto)
        {
            var value = _mapper.Map<Booking>(BookingDto);
            _bookingService.TAdd(value);
            return Ok("Booking successfully added");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto BookingDto)
        {
            var existBooking = _bookingService.TGetById(BookingDto.BookingID);
            if (existBooking == null)
            {
                return NotFound("Booking not found");
            }
            var result = _mapper.Map(BookingDto, existBooking);
            _bookingService.TUpdate(result);
            return Ok("Booking successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var existBooking = _bookingService.TGetById(id);
            if (existBooking == null)
            {
                return NotFound("Booking not found");
            }
            _bookingService.TRemove(existBooking);
            return Ok("Booking successfully deleted");
        }
    }
}
