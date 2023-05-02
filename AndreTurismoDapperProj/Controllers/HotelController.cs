using AndreTurismoDapperProj.Models;
using AndreTurismoDapperProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoDapperProj.Controllers
{
    [Route("api/Hotel")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelController()
        {
            _hotelService = new HotelService();
        } 

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var hotel = _hotelService.GetAll();
            if (hotel is null) return NotFound();

            return Ok(hotel);
        }
        /*[HttpGet("{Id}", Name = "GetHotelId")]
        public ActionResult GetId(int id)
        {
            var hotel = _hotelRepository.GetId(id);
            if (hotel is null) return NotFound();

            return Ok(hotel);
        }*/
        [HttpPost]
        public async Task<ActionResult> Create(Hotel hotel)
        {
            if (hotel is null) return NotFound();
            hotel = await _hotelService.Create(hotel);
            return Ok(hotel);
        }
        /*[HttpDelete]
        public ActionResult Delete(int id)
        {
            var hotel = (_hotelRepository.GetId(id));
            if (hotel is null) return NotFound();
            _hotelRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(Hotel hotel)
        {
            var id = _hotelRepository.GetId(hotel.Id);
            if (id is null) return NotFound();
            _hotelRepository.Update(hotel);
            return Ok();
        }*/
    }
}
