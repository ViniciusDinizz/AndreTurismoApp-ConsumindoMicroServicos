using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoDapperProj.Models
{
    public class Customer
    {
        public readonly static string INSERT = "INSERT INTO Customer(Name, Telephone, DtRegister, IdAddress) " +
                    "VALUES (@Name, @Telephone, @DtRegister, @IdAddress); SELECT CAST(SCOPE_IDENTITY() as int)";
        public readonly static string GETALL = "SELECT client.*, address.*, city.*" +
                                "FROM[Customer] client JOIN[Address] address on client.[IdAddress] = address.[Id]" +
                                "JOIN[City] city on city.[Id] = address.[IdCity]";
        public readonly static string GETID = "SELECT client.*, [address].*, city.*" +
                                "FROM[Customer] client JOIN[Address] [address] ON client.[IdAddress] = address.[Id]" +
                                "JOIN[City] city on city.[Id] = address.[IdCity] WHERE client.Id = @Id";
        public readonly static string DELETE = "DELETE FROM Customer WHERE Id = @Id";
        public readonly static string UPDATE = "UPDATE Customer SET Name = @Name, Telephone = @Telephone WHERE Id = @Id";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public DateTime DtRegister { get; set; }
        public Address IdAddress { get; set; }
    }
}
