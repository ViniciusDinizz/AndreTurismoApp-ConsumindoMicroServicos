using AndreTurismoDapperProj.Models;
using AndreTurismoDapperProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoDapperProj.Controllers
{
    [Route("api/Address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;

        public AddressController()
        {
            _addressService = new AddressService();
            _cityService = new CityService();
        }

        [HttpGet]
        public async Task<List<Address>> GetAll()
        {
            return await _addressService.GetAll();
        }
        [HttpGet("{cep}", Name = "GetAddressId")]
        public async Task<ActionResult<AddressDTO>> GetId(string cep)
        {
            var address = await _addressService.GetCep(cep);
            if (address is null) return NotFound();
            AddressDTO addressDTO = address.Value;
            Address addressresult = new(addressDTO);
            return Ok(addressresult);
        }
        [HttpPost]
        public async Task<ActionResult<Address>> Create(Address address)
        {
            if (address.Number ==  0) return NotFound("Sem número.");
            if (address.Cep.Length != 8) { address.Cep = string.Empty; }
            
            address = await _addressService.Create(address);
            return Ok(address);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult> Update(int Id, Address address)
        {
            var addressExist = _addressService.GetId(Id);
            if (addressExist is null) return NotFound();
            address.Id = addressExist.Id;
            await _addressService.Update(Id, address);
            return Ok(address);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var city = await _addressService.GetId(id);
            if (city is null) return NotFound();
            await _addressService.Delete(id);
            return Ok($"Id:{id} Delete Sucess");
        }
    }
}
