using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoDapperProj.Models;

namespace AndreTurismoDapperProj.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetId(int id);
        Customer Create(Customer customer);
        bool Update(Customer customer);
        bool Delete(int id);
    }
}
