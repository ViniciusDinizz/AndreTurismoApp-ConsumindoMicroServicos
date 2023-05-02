using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoDapperProj.Models
{
    public class Address
    {
        public readonly static string INSERT = "INSERT INTO Address(Street, Number, Burgh, Cep, Complement, DtRegister, IdCity) " +
            "VALUES (@Street, @Number, @Burgh, @Cep, @Complement, @DtRegister, @IdCity); SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public readonly static string GETALL = "SELECT a.Id, a.Street, a.Number, a.Burgh, a.Cep, a.Complement, a.DtRegister, c.Id, c.Description, c.DtRegister " +
            "FROM Address a JOIN City c on a.IdCity = c.Id";
        public readonly static string GETID = "SELECT a.Id, a.Street, a.Number, a.Burgh, a.Cep, a.Complement, a.DtRegister, c.Id, c.Description, c.DtRegister " +
            "FROM Address a JOIN City c on a.IdCity = c.Id WHERE Id = @Id";
        public readonly static string DELETE = "DELETE FROM Address WHERE Id = @Id";
        public readonly static string UPDATE = "UPDATE Address SET Street = @Street, Number = @Number, Burgh = @Burgh, " +
            "Cep = @Cep, Complement = @Complement WHERE Id = @Id";

        public Address() { }
        public Address(AddressDTO dto)
        {
            Street = dto.Logradouro;
            Burgh = dto.Bairro;
            Cep = dto.CEP;
            IdCity = new City() { Description = dto.Localidade, DtRegister = DateTime.Now };
            Complement = dto.Complemento;
        }
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Burgh { get; set; }
        public string Cep { get; set; }
        public string? Complement { get; set; }
        public DateTime? DtRegister { get; set; }
        public City IdCity { get; set; }
    }
}
