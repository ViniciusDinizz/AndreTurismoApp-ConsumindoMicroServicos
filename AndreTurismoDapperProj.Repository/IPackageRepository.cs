using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.Repository
{
    public interface IPackageRepository
    {
        List<Package> GetAll();
        Package GetId(int id);
        Package Create(Package package);
        bool Update(Package package);
        bool Delete(int id);
    }
}
