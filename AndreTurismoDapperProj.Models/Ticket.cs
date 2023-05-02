using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoDapperProj.Models
{
    public class Ticket
    {
        public readonly static string INSERT = "INSERT INTO Ticket(Value, Date, IdOrigin, IdDestin) " +
            "VALUES (@Value, @Date, @IdOrigin, @IdDestin); SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public readonly static string GETALL = "SELECT ticket.[Id],ticket.[Value], ticket.[Date], " +
            "addressOrigin.[Id], addressOrigin.[Street], addressOrigin.[Number], " +
            "addressOrigin.[Burgh], addressOrigin.[Cep], addressOrigin.[Complement], " +
            "cityOrigin.[Id], cityOrigin.[Description], cityOrigin.[DtRegister], " +
            "addressDestin.[Id], addressDestin.[Street], addressDestin.[Number], " +
            "addressDestin.[Burgh], addressDestin.[Cep], addressDestin.[Complement], " +
            "cityDestin.[Id], cityDestin.[Description], cityDestin.[DtRegister] " +
            "FROM[Ticket] ticket JOIN[Address] addressDestin ON ticket.[IdDestin] = addressDestin.[Id] " +
            "JOIN[City] cityDestin ON addressDestin.[IdCity] = cityDestin.[Id] " +
            "JOIN[Address] addressOrigin ON ticket.[IdOrigin] = addressOrigin.[Id] " +
            "JOIN[City] cityOrigin ON addressOrigin.[IdCIty] = cityOrigin.[Id]";
        public readonly static string GETID = "SELECT ticket.[Id],ticket.[Value], ticket.[Date], " +
            "addressOrigin.[Id], addressOrigin.[Street], addressOrigin.[Number], " +
            "addressOrigin.[Burgh], addressOrigin.[Cep], addressOrigin.[Complement], " +
            "cityOrigin.[Id], cityOrigin.[Description], cityOrigin.[DtRegister], " +
            "addressDestin.[Id], addressDestin.[Street], addressDestin.[Number], " +
            "addressDestin.[Burgh], addressDestin.[Cep], addressDestin.[Complement], " +
            "cityDestin.[Id], cityDestin.[Description], cityDestin.[DtRegister] " +
            "FROM[Ticket] ticket JOIN[Address] addressDestin ON ticket.[IdDestin] = addressDestin.[Id] " +
            "JOIN[City] cityDestin ON addressDestin.[IdCity] = cityDestin.[Id] " +
            "JOIN[Address] addressOrigin ON ticket.[IdOrigin] = addressOrigin.[Id] " +
            "JOIN[City] cityOrigin ON addressOrigin.[IdCIty] = cityOrigin.[Id] WHERE Id = @Id";
        public readonly static string DELETE = "DELETE FROM Ticket WHERE Id = @Id";
        public readonly static string UPDATE = "UPDATE Ticket SET Value = @Value WHERE Id = @Id";

        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime DtRegister { get; set; }
        public Address IdOrigin { get; set; }
        public Address IdDestin { get; set; }
    }
}
