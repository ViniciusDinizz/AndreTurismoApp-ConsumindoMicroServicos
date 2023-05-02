using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.Repository
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
        Ticket GetId(int id);
        Ticket Create(Ticket ticket);
        bool Update(Ticket ticket);
        bool Delete(int id);
    }
}
