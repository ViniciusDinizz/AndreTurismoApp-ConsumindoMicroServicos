using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoDapperProj.Models;
using AndreTurismoDapperProjAddressService.Data;
using AndreTurismoDapperProjAddressService.Service;
using AndreTurismoDapperProj.Repository;
using NuGet.Protocol;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using AndreTurismoDapperProj.CityService.Data;

namespace AndreTurismoDapperProjAddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AndreTurismoDapperProjAddressServiceContext _context;
        private readonly PostOfficeService _officeService;

        public AddressesController(AndreTurismoDapperProjAddressServiceContext context, PostOfficeService officeService)
        {
            _context = context;
            _officeService = officeService;
        }
        // GET: api/Addresses
        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            return await _context.Address.Include(a => a.IdCity).ToListAsync();
        }

        [HttpGet("{cep:length(8)}", Name = "GetCep")]
        public async Task<ActionResult<Address>> GetPostOffices(string cep)
        {
            if (cep == null)
            {
                return NotFound();
            }
            AddressDTO address = _officeService.GetAddress(cep).Result;

            return Ok(address);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(address);
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            if (_context.Address == null)
            {
                return Problem("Entity set 'AndreTurismoAppAddressServiceContext.Address'  is null.");
            }
            if (address.Cep.Length == 8) { AddressDTO addresDTO = await _officeService.GetAddress(address.Cep); if (addresDTO == null)  return NotFound("Cep inválido") ; address = new(addresDTO); }
            if (await _context.City.FirstOrDefaultAsync(c => c.Description == address.IdCity.Description) != null) { address.IdCity =  _context.City.FirstOrDefaultAsync(c => c.Description == address.IdCity.Description).Result; }
            Address addressExist = await _context.Address.Include(a => a.IdCity).FirstOrDefaultAsync(a => a.Number == address.Number && a.IdCity.Description == address.IdCity.Description);
            if (addressExist == null) { _context.Address.Add(address); await _context.SaveChangesAsync(); return CreatedAtAction("GetAddress", new { id = address.Id}, address); }

            return addressExist;
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.Address?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
