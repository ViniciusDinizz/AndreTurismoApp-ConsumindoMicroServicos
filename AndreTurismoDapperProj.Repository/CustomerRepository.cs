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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _conn;

        public CustomerRepository(DapperContext conn) => _conn = conn;

        public Customer Create(Customer customer)
        {
            using(var db = _conn.CreateConnection())
            {
                customer.Id = db.ExecuteScalar<int>(Customer.INSERT, new {@Name = customer.Name, @Telephone = customer.Telephone,
                                                                        @DtRegister = customer.DtRegister, @IdAddress = customer.IdAddress.Id});

            }
            return customer;
        }

        public bool Delete(int id)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Customer.DELETE, new { @Id = id });
                status = true;
            }
            return status;
        }

        public List<Customer> GetAll()
        {
            List<Customer> lstcustomer = new();
            using(var db = _conn.CreateConnection())
            {
                lstcustomer = (List<Customer>)db.Query<Customer, Address, City, Customer>(Customer.GETALL, (customer, address, city) =>
                    {
                        customer.IdAddress = address;
                        customer.IdAddress.IdCity = city;
                        return customer;
                    }
                    );
            }
            return lstcustomer;
        }

        public Customer GetId(int id)
        {
            Customer customer = new();
            using(var db = _conn.CreateConnection())
            {
                customer = (Customer)db.Query<Customer, Address, City, Customer>(Customer.GETID, (customer, address, city) => 
                    {
                        customer.IdAddress = address;
                        customer.IdAddress.IdCity = city;
                        return customer;
                    }, new {@Id = id});
            }
            return customer;
        }

        public bool Update(Customer customer)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Customer.UPDATE, customer);
                status = true;
            }
            return status;
        }
    }
}
