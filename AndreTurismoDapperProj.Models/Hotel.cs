using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoDapperProj.Models
{
    public class Hotel
    {
        public readonly static string INSERT = "INSERT INTO Hotel (Name, DtRegister, Value, IdAddress) " +
            "VALUES (@Name, @DtRegister, @Value, @IdAddress); SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public readonly static string GETALL = "SELECT hotel.[Id], hotel.[Name], " +
            "hotel.[DtRegister],hotel.[IdAddress], " +
            "address.[Id], address.[Street], " +
            "address.[Number], " +
            "address.[Burgh], address.[Cep], " +
            "address.[Complement], address.[DtRegister], city.[Id], city.[Description], " +
            "city.[DtRegister] " +
            "FROM [Hotel] hotel JOIN [Address] address ON hotel.[IdAddress] = address.[Id] " +
            "JOIN [City] city ON city.[Id] = address.[IdCity]";
        public readonly static string GETID = "SELECT hotel.[Id], hotel.[Name], " +
            "hotel.[DtRegister],hotel.[IdAddress], " +
            "address.[Id], address.[Street], " +
            "address.[Number], " +
            "address.[Burgh], address.[Cep], " +
            "address.[Complement], address.[DtRegister], city.[Id], city.[Description], " +
            "city.[DtRegister] " +
            "FROM [Hotel] hotel JOIN [Address] address ON hotel.[IdAddress] = address.[Id] " +
            "JOIN [City] city ON city.[Id] = address.[IdCity] WHERE hotel.Id = @Id";
        public readonly static string DELETE = "DELETE FROM Hotel WHERE Id = @Id";
        public readonly static string UPDATE = "UPDATE Hotel SET Name = @Name, Value = @Value WHERE Id = @Id";

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime DtRegister { get; set; }
        public Address IdAddress { get; set; }
    }
}
