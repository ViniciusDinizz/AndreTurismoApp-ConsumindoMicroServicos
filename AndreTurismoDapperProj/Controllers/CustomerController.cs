using AndreTurismoDapperProj.Models;
using AndreTurismoDapperProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoDapperProj.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var customer = _customerService.GetAll();
            if (customer is null) return NotFound();

            return Ok(customer);
        }
        /*[HttpGet("{Id}", Name = "GetCustomerId")]
        public ActionResult GetId(int id)
        {
            var city = _customerRepository.GetId(id);
            if (city is null) return NotFound();

            return Ok(city);
        }*/
        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            if (customer is null) return NotFound(customer);
            customer = await _customerService.Create(customer);
            return Ok(customer);
        }
        /*[HttpDelete]
        public ActionResult Delete(int id)
        {
            var customer = (_customerRepository.GetId(id));
            if (customer is null) return NotFound();
            _customerRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(Customer customer)
        {
            var id = _customerRepository.GetId(customer.Id);
            if (id is null) return NotFound();
            _customerRepository.Update(customer);
            return Ok();
        }*/
    }
}
