using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoDapperProj.Models
{
    public class Package
    {
        public readonly static string INSERT = "INSERT INTO Package(IdHotel, IdTicket, IdCustomer, DtRegister, Value) " +
                "Values (@IdHotel, @IdTicket, @IdCustomer, @DtRegister, @Value); SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public readonly static string GETALL = "SELECT package.[Id], " +
            "package.[DtRegister], package.[Value], " +
            "hotel.[Id], hotel.[Name], hotel.[Value], hotel.[DtRegister], " +
            "addressHotel.[Id], addressHotel.[Street], " +
            "addressHotel.[Number], addressHotel.[Burgh], " +
            "addressHotel.[Cep], addressHotel.[Complement], addressHotel.[DtRegister], " +
            "cityHotel.[Id], cityHotel.[Description], cityHotel.[DtRegister], " +
            "ticket.[Id], ticket.[Value], ticket.[Date], " +
            "addressOrigin.[Id], addressOrigin.[Street], addressOrigin.[Number], " +
            "addressOrigin.[Burgh], addressOrigin.[Cep], addressOrigin.[Complement], " +
            "cityOrigin.[Id], cityOrigin.[Description], cityOrigin.[DtRegister], " +
            "addressDestin.[Id], addressDestin.[Street], addressDestin.[Number], " +
            "addressDestin.[Burgh], addressDestin.[Cep], addressDestin.[Complement], " +
            "cityDestin.[Id], cityDestin.[Description], cityDestin.[DtRegister], " +
            "customer.[Id], customer.[Name], customer.[Telephone], customer.[DtRegister], " +
            "[addresscustomer].[Id], [addresscustomer].[Street],[addresscustomer].[Number], " +
            "[addresscustomer].[Burgh], [addresscustomer].[Cep], [addresscustomer].[Complement], [addresscustomer].[DtRegister], " +
            "citycustomer.[Id], citycustomer.[Description], citycustomer.[DtRegister] " +
            "FROM [Package] package JOIN [Hotel] hotel on package.[IdHotel] = hotel.[Id] " +
            "JOIN [Address] addressHotel ON hotel.[IdAddress] = addressHotel.[Id] " +
            "JOIN [City] cityHotel ON cityHotel.[Id] = addressHotel.[IdCity] " +
            "JOIN [Ticket] ticket ON package.[IdTicket] = ticket.[Id] " +
            "JOIN [Address] addressDestin ON ticket.[IdDestin] = addressDestin.[Id] " +
            "JOIN [City] cityDestin ON addressDestin.[IdCity] = cityDestin.[Id] " +
            "JOIN [Address] addressOrigin ON ticket.[IdOrigin] = addressOrigin.[Id] " +
            "JOIN [City] cityOrigin on addressOrigin.[IdCity] = cityOrigin.[Id] " +
            "JOIN [Customer] customer ON package.[IdCustomer] = customer.[Id] " +
            "JOIN [Address] [addresscustomer] ON customer.[IdAddress] = [addresscustomer].[Id] " +
            "JOIN [City] citycustomer ON citycustomer.[Id] = [addresscustomer].[IdCity]";
        public readonly static string GETID = "SELECT package.[Id], " +
            "package.[DtRegister], package.[Value], " +
            "hotel.[Id], hotel.[Name], hotel.[Value], hotel.[DtRegister], " +
            "addressHotel.[Id], addressHotel.[Street], " +
            "addressHotel.[Number], addressHotel.[Burgh], " +
            "addressHotel.[Cep], addressHotel.[Complement], addressHotel.[DtRegister], " +
            "cityHotel.[Id], cityHotel.[Description], cityHotel.[DtRegister], " +
            "ticket.[Id], ticket.[Value], ticket.[Date], " +
            "addressOrigin.[Id], addressOrigin.[Street], addressOrigin.[Number], " +
            "addressOrigin.[Burgh], addressOrigin.[Cep], addressOrigin.[Complement], " +
            "cityOrigin.[Id], cityOrigin.[Description], cityOrigin.[DtRegister], " +
            "addressDestin.[Id], addressDestin.[Street], addressDestin.[Number], " +
            "addressDestin.[Burgh], addressDestin.[Cep], addressDestin.[Complement], " +
            "cityDestin.[Id], cityDestin.[Description], cityDestin.[DtRegister], " +
            "customer.[Id], customer.[Name], customer.[Telephone], customer.[DtRegister], " +
            "[addresscustomer].[Id], [addresscustomer].[Street],[addresscustomer].[Number], " +
            "[addresscustomer].[Burgh], [addresscustomer].[Cep], [addresscustomer].[Complement], [addresscustomer].[DtRegister], " +
            "citycustomer.[Id], citycustomer.[Description], citycustomer.[DtRegister] " +
            "FROM [Package] package JOIN [Hotel] hotel on package.[IdHotel] = hotel.[Id] " +
            "JOIN [Adress] addressHotel ON hotel.[IdAddress] = addressHotel.[Id] " +
            "JOIN [City] cityHotel ON cityHotel.[Id] = addressHotel.[IdCity] " +
            "JOIN [Ticket] ticket ON package.[IdTicket] = ticket.[Id] " +
            "JOIN [Address] addressDestin ON ticket.[IdDestin] = addressDestin.[Id] " +
            "JOIN [City] cityDestin ON addressDestin.[IdCity] = cityDestin.[Id] " +
            "JOIN [Address] addressOrigin ON ticket.[IdOrigin] = addressOrigin.[Id] " +
            "JOIN [City] cityOrigin on addressOrigin.[IdCity] = cityOrigin.[Id] " +
            "JOIN [Customer] customer ON package.[IdCustomer] = customer.[Id] " +
            "JOIN [Address] [addresscustomer] ON customer.[IdAddress] = [addresscustomer].[Id] " +
            "JOIN [City] citycustomer ON citycustomer.[Id] = [addresscustomer].[IdCity] WHERE package.Id = @Id";
        public readonly static string DELETE = "DELETE FROM Package WHERE Id = @Id";
        public readonly static string UPDATE = "UPDATE Package SET Value = @Value WHERE Id = @Id";

        public int Id { get; set; }
        public DateTime DtRegister { get; set; }
        public decimal Value { get; set; }
        public Hotel IdHotel { get; set; }
        public Ticket IdTicket { get; set; }
        public Customer IdCustomer { get; set; }
    }
}
