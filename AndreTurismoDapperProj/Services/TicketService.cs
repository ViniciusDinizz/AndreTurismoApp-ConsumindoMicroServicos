using AndreTurismoDapperProj.Models;
using Newtonsoft.Json;

namespace AndreTurismoDapperProj.Services
{
    public class TicketService
    {
        static readonly HttpClient ticketClient = new HttpClient();

        public async Task<List<Ticket>> GetAll()
        {
            try
            {
                HttpResponseMessage response = await TicketService.ticketClient.GetAsync("https://localhost:7007/api/Cities");
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Ticket>>(ticket);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Ticket> Create(Ticket ticket)
        {
            try
            {
                HttpResponseMessage response = await TicketService.ticketClient.PostAsJsonAsync("https://localhost:7007/api/Cities", ticket);
                response.EnsureSuccessStatusCode();
                string ticketResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticketResult);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}