using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.CustomerService.Data
{
    public class AndreTurismoDapperProjCustomerServiceContext : DbContext
    {
        public AndreTurismoDapperProjCustomerServiceContext (DbContextOptions<AndreTurismoDapperProjCustomerServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoDapperProj.Models.Customer> Customer { get; set; } = default!;
    }
}
