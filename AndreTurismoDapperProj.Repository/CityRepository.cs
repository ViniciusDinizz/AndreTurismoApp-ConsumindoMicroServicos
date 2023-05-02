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
    public class CityRepository : ICityRepository
    {
        private readonly DapperContext _conn;

        public CityRepository(DapperContext conn) =>_conn = conn;

        public City Create(City city)
        {
            using(var db = _conn.CreateConnection())
            {
                var id = db.ExecuteScalar<int>(City.INSERT, city);
                city.Id = id;
            }
            return city;
        }

        public bool Delete(int id)
        {
            bool status = false;
            using( var db = _conn.CreateConnection())
            {
                db.Execute(City.DELETE, new { @Id = id });
                status = true;
            }
            return status;
        }

        public List<City> GetAll()
        {
            List<City> lstcity = new();
            using( var db = _conn.CreateConnection())
            {
                lstcity = (List<City>)db.Query<City>(City.GETALL);
            }
            return lstcity;
        }

        public City GetId(int id)
        {
            City city = new();
            using(var db = _conn.CreateConnection())
            {
                city = db.QueryFirstOrDefault<City>(City.GETID, new { @Id = id });
            }
            return (City)city;
        }

        public bool Update(City city)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(City.UPDATE, city);
                status = true;            
            }
            return status;
        }
    }
}
