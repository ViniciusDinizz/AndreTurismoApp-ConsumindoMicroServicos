using AndreTurismoDapperProj.Models;
using AndreTurismoDapperProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoDapperProj.Controllers
{
    [Route("api/City")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController()
        {
            _cityService = new CityService();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var city = await _cityService.GetAll();
            if (city is null) return NotFound();

            return Ok(city);
        }
        [HttpGet("{Id}", Name = "GetCityId")]
        public async Task<ActionResult> GetId(int Id)
        {
            var city = await _cityService.GetId(Id);
            if (city is null) return NotFound();

            return Ok(city);
        }
        [HttpPost]
        public async Task<ActionResult> Create(City city)
        {
            if (city is not null)
            {
                city = await _cityService.Create(city);
                return Ok(city);
            }

            return NotFound();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Update(int Id, City city)
        {
            var cityid = await _cityService.GetId(Id);
            if (cityid is null) return NotFound("Cidade não encontrada");
            city.Id = cityid.Id;
            await _cityService.Update(Id, city);
            return Ok(city);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var city = await _cityService.GetId(id);
            if (city is null) return NotFound();
            await _cityService.Delete(id);
            return Ok("Delete Sucess.");
        }
    }
}
