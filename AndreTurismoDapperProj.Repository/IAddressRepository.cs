using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.Repository
{
    public interface IAddressRepository
    {
        List<Address> GetAll();
        Address GetId(int id);
        Address Create(Address address);
        bool Update(Address address);
        bool Delete(int id);
    }
}
