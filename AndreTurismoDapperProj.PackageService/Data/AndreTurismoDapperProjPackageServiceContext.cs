using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.PackageService.Data
{
    public class AndreTurismoDapperProjPackageServiceContext : DbContext
    {
        public AndreTurismoDapperProjPackageServiceContext (DbContextOptions<AndreTurismoDapperProjPackageServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoDapperProj.Models.Package> Package { get; set; } = default!;
    }
}
