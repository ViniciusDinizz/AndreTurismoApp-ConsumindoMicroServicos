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
    public class TicketRepository : ITicketRepository
    {
        private readonly DapperContext _conn;

        public TicketRepository(DapperContext conn) => _conn = conn;

        public Ticket Create(Ticket ticket)
        {
            using(var db = _conn.CreateConnection())
            {
                ticket.Id = db.ExecuteScalar<int>(Ticket.INSERT, new
                {
                    @Value = ticket.Value,
                    @Date = ticket.DtRegister,
                    @IdOrigin = ticket.IdOrigin.Id,
                    @IdDestin = ticket.IdDestin.Id
                });
            }
            return ticket;
        }

        public bool Delete(int id)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Ticket.DELETE, new { @Id = id });
                status = true;
            }
            return status;
        }

        public List<Ticket> GetAll()
        {
            List<Ticket> lstticket = new();
            using(var db = _conn.CreateConnection())
            {
                lstticket = (List<Ticket>)db.Query<Ticket, Address, City, Address, City, Ticket>(Ticket.GETALL, (ticket, addresso, cityo, adressd, cityd) =>
                {
                    ticket.IdOrigin = addresso;
                    ticket.IdOrigin.IdCity = cityo;
                    ticket.IdDestin = adressd;
                    ticket.IdDestin.IdCity = cityd;
                    return ticket;
                });
            }
            return lstticket;
        }

        public Ticket GetId(int id)
        {
            Ticket ticket = new();
            using(var db = _conn.CreateConnection())
            {
                ticket = (Ticket)db.Query<Ticket, Address, City, Address, City, Ticket>(Ticket.GETID, (tickett, addresso, cityo, addressd, cityd) =>
                {
                    ticket.IdOrigin = addresso;
                    ticket.IdOrigin.IdCity = cityo;
                    ticket.IdDestin = addressd;
                    ticket.IdDestin.IdCity= cityd;
                    return ticket;
                }, new {@Id = id});
            }
            return ticket;
        }

        public bool Update(Ticket ticket)
        {
            bool status = false;
            using(var db = _conn.CreateConnection())
            {
                db.Execute(Ticket.UPDATE, ticket);
                status = true;
            }
            return status;
        }
    }
}
