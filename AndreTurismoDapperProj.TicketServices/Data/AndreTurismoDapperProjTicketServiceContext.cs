using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.TicketService.Data
{
    public class AndreTurismoDapperProjTicketServiceContext : DbContext
    {
        public AndreTurismoDapperProjTicketServiceContext (DbContextOptions<AndreTurismoDapperProjTicketServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoDapperProj.Models.Ticket> Ticket { get; set; } = default!;
    }
}
