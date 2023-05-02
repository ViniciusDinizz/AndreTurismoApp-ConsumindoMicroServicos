using AndreTurismoDapperProj.Models;
using AndreTurismoDapperProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoDapperProj.Controllers
{
    [Route("api/Ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController()
        {
            _ticketService = new TicketService();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var ticket = await _ticketService.GetAll();
            if (ticket is null) return NotFound();

            return Ok(ticket);
        }
        /*[HttpGet("{Id}", Name = "GetTicketlId")]
        public ActionResult GetId(int id)
        {
            var ticket = _ticketRepository.GetId(id);
            if (ticket is null) return NotFound();

            return Ok(ticket);
        }*/
        [HttpPost]
        public async Task<ActionResult> Create(Ticket ticket)
        {
            if (ticket is null) return NotFound();
            ticket = await _ticketService.Create(ticket);
            return Ok(ticket);
        }
        /*[HttpDelete]
        public ActionResult Delete(int id)
        {
            var ticket = (_ticketRepository.GetId(id));
            if (ticket is null) return NotFound();
            _ticketRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(Ticket ticket)
        {
            var id = _ticketRepository.GetId(ticket.Id);
            if (id is null) return NotFound();
            _ticketRepository.Update(ticket);
            return Ok();
        }*/
    }
}
