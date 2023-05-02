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
    public class PackageRepository : IPackageRepository
    {
        private readonly DapperContext _conn;

        public PackageRepository(DapperContext conn) => _conn = conn;

        public Package Create(Package package)
        {
            using(var db = _conn.CreateConnection())
            {
                package.Id = db.ExecuteScalar<int>(Package.INSERT, new
                {
                    @IdHotel = package.IdHotel.Id,
                    @IdTicket = package.IdTicket.Id,
                    @IdCustomer = package.IdCustomer.Id,
                    @DtRegister = package.DtRegister,
                    @Value = package.Value
                });
            }
            return package;
        }

        public bool Delete(int id)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Package.DELETE, new { @Id = id });
                status = true;
            }
            return status;
        }

        public List<Package> GetAll()
        {
            List<Package> lstpackage = new ();
            using(var db = _conn.CreateConnection())
            {
                lstpackage = (List<Package>)db.Query<Package>(Package.GETALL, new[]
                {
                    typeof(Package),
                    typeof(Hotel),
                    typeof(Address),
                    typeof(City),
                    typeof(Ticket),
                    typeof(Address),
                    typeof(City),
                    typeof(Address),
                    typeof(City),
                    typeof(Customer),
                    typeof(Address),
                    typeof(City)
                },
                pack => 
                {
                    Package package = pack[0] as Package;
                    Hotel hotel = pack[1] as Hotel;
                    Address addressHotel = pack[2] as Address;
                    City cityHotel = pack[3] as City;
                    Ticket ticket = pack[4] as Ticket;
                    Address addressOrigin = pack[5] as Address;
                    City cityOrigin = pack[6] as City;
                    Address addressDestin = pack[7] as Address;
                    City cityDestin = pack[8] as City;
                    Customer customer = pack[9] as Customer;
                    Address addresscustomer = pack[10] as Address;
                    City citycustomer = pack[11] as City;

                    package.IdHotel = hotel;
                    package.IdHotel.IdAddress = addressHotel;
                    package.IdHotel.IdAddress.IdCity = cityHotel;
                    package.IdTicket = ticket;
                    package.IdTicket.IdOrigin = addressOrigin;
                    package.IdTicket.IdOrigin.IdCity = cityOrigin;
                    package.IdTicket.IdDestin = addressDestin;
                    package.IdTicket.IdDestin.IdCity = cityDestin;
                    package.IdCustomer = customer;
                    package.IdCustomer.IdAddress = addresscustomer;
                    package.IdCustomer.IdAddress.IdCity = citycustomer;

                    return package;
                });
            }
            return lstpackage;
        }

        public Package GetId(int id)
        {
            Package package = new();
            using (var db = _conn.CreateConnection())
            {
                package = (Package)db.Query<Package>(Package.GETID, new[]
                {
                    typeof(Package),
                    typeof(Hotel),
                    typeof(Address),
                    typeof(City),
                    typeof(Ticket),
                    typeof(Address),
                    typeof(City),
                    typeof(Address),
                    typeof(City),
                    typeof(Customer),
                    typeof(Address),
                    typeof(City)
                },
                pack =>
                {
                    Package package = pack[0] as Package;
                    Hotel hotel = pack[1] as Hotel;
                    Address addressHotel = pack[2] as Address;
                    City cityHotel = pack[3] as City;
                    Ticket ticket = pack[4] as Ticket;
                    Address addressOrigin = pack[5] as Address;
                    City cityOrigin = pack[6] as City;
                    Address addressDestin = pack[7] as Address;
                    City cityDestin = pack[8] as City;
                    Customer customer = pack[9] as Customer;
                    Address addresscustomer = pack[10] as Address;
                    City citycustomer = pack[11] as City;

                    package.IdHotel = hotel;
                    package.IdHotel.IdAddress = addressHotel;
                    package.IdHotel.IdAddress.IdCity = cityHotel;
                    package.IdTicket = ticket;
                    package.IdTicket.IdOrigin = addressOrigin;
                    package.IdTicket.IdOrigin.IdCity = cityOrigin;
                    package.IdTicket.IdDestin = addressDestin;
                    package.IdTicket.IdDestin.IdCity = cityDestin;
                    package.IdCustomer = customer;
                    package.IdCustomer.IdAddress = addresscustomer;
                    package.IdCustomer.IdAddress.IdCity = citycustomer;

                    return package;
                }, new {@Id = id});
            }
            return package;
        }

        public bool Update(Package package)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Package.UPDATE, package);
                status = true;
            }
            return status;
        }
    }
}
