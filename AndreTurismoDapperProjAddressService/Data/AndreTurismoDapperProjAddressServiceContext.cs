using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProjAddressService.Data
{
    public class AndreTurismoDapperProjAddressServiceContext : DbContext
    {
        public AndreTurismoDapperProjAddressServiceContext (DbContextOptions<AndreTurismoDapperProjAddressServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoDapperProj.Models.Address> Address { get; set; } = default!;
        public DbSet<AndreTurismoDapperProj.Models.City> City { get; set; } = default!;
    }
}
