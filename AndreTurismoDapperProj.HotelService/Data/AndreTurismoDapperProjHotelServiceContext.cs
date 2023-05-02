using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.HotelService.Data
{
    public class AndreTurismoDapperProjHotelServiceContext : DbContext
    {
        public AndreTurismoDapperProjHotelServiceContext (DbContextOptions<AndreTurismoDapperProjHotelServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoDapperProj.Models.Hotel> Hotel { get; set; } = default!;
    }
}
