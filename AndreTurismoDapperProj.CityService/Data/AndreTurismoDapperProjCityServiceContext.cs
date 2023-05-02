using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.CityService.Data
{
    public class AndreTurismoDapperProjCityServiceContext : DbContext
    {
        public AndreTurismoDapperProjCityServiceContext (DbContextOptions<AndreTurismoDapperProjCityServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoDapperProj.Models.City> City { get; set; } = default!;
    }
}
