using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.Repository
{
    public interface ICityRepository
    {
        List<City> GetAll();
        City GetId(int id);
        City Create(City city);
        bool Update(City city);
        bool Delete(int id);
    }
}
