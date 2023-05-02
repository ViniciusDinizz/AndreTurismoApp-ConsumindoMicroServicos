using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.Repository
{
    public interface IHotelRepository
    {
        List<Hotel> GetAll();
        Hotel GetId(int id);
        Hotel Create(Hotel hotel);
        bool Update(Hotel hotel);
        bool Delete(int id);
    }
}
