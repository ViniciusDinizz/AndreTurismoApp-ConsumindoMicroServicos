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
    public class HotelRepository : IHotelRepository
    {
        private readonly DapperContext _conn;

        public HotelRepository(DapperContext conn) => _conn = conn;

        public Hotel Create(Hotel hotel)
        {
            using(var db = _conn.CreateConnection())
            {
                hotel.Id = db.ExecuteScalar<int>(Hotel.INSERT, new
                {
                    @Name = hotel.Name,
                    @DtRegister = hotel.DtRegister,
                    @Value = hotel.Value,
                    @IdAddress = hotel.IdAddress.Id
                    });
            }
            return hotel;
        }

        public bool Delete(int id)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Hotel.DELETE, new { @Id = id });
                status = true;
            }
            return status;
        }

        public List<Hotel> GetAll()
        {
            List<Hotel> lsthotel = new();
            using(var db = _conn.CreateConnection())
            {
                lsthotel = (List<Hotel>)db.Query<Hotel, Address, City, Hotel>(Hotel.GETALL, (hotel, address, city) =>
                {
                    hotel.IdAddress = address;
                    hotel.IdAddress.IdCity = city;
                    return hotel;
                });
            }
            return lsthotel;
        }

        public Hotel GetId(int id)
        {
            Hotel hotel = new();
            using(var db = _conn.CreateConnection())
            {
                hotel = (Hotel)db.Query<Hotel, Address, City, Hotel>(Hotel.GETID, (hotell, address, city) =>
                {
                    hotell.IdAddress = address;
                    hotell.IdAddress.IdCity = city;
                    return hotel;
                }, new {@Id = id});
                return hotel;
            }
        }

        public bool Update(Hotel hotel)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Hotel.UPDATE, hotel);
                status = true;
            }
            return status;
        }
    }
}
