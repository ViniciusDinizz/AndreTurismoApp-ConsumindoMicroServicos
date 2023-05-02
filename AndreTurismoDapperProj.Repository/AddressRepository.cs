using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoDapperProj.Context;
using AndreTurismoDapperProj.Models;
using Dapper;

namespace AndreTurismoDapperProj.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DapperContext _conn;

        public AddressRepository(DapperContext conn) => _conn = conn;

        public Address Create(Address address)
        {
            using(var db = _conn.CreateConnection())
            {
                address.Id = db.ExecuteScalar<int>(Address.INSERT, new { @Street = address.Street, @Number = address.Number,
                                                                        @Burgh = address.Burgh, @Cep = address.Cep, @Complement = address.Complement,
                                                                        @DtRegister = address.DtRegister, @IdCity = address.IdCity.Id});
            }
            return address;
        }

        public bool Delete(int id)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Address.DELETE, new { id = id });
                status = true;
            }
            return status;
        }

        public List<Address> GetAll()
        {
            List<Address> lstaddress = new();
            using(var db = _conn.CreateConnection())
            {
                lstaddress = (List<Address>)db.Query<Address, City, Address>(Address.GETALL, (address, city) => 
                    { address.IdCity = city; return address;});
            }
            return lstaddress;
        }

        public Address GetId(int id)
        {
            Address address = new();
            using(var db = _conn.CreateConnection())
            {
                address = (Address)db.Query<Address, City, Address>(Address.GETID, (addres, city) =>
                    { addres.IdCity = city; return addres; }, new { @id = id });
            }
            return address;
        }

        public bool Update(Address city)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Address.UPDATE, city);
                status = true;
            }
            return status;
        }
    }
}
