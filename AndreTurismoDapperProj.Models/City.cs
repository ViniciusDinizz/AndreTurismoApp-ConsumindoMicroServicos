namespace AndreTurismoDapperProj.Models
{
    public class City
    {
        public readonly static string INSERT = "INSERT INTO City(Description, DtRegister) VALUES (@Description, @DtRegister); SELECT CAST(scope_Identity() as int)";
        public readonly static string GETALL = "SELECT Id , Description, DtRegister FROM City";
        public readonly static string GETID = "SELECT Id , Description, DtRegister FROM City WHERE Id = @Id";
        public readonly static string DELETE = "DELETE FROM City WHERE Id = @Id";
        public readonly static string UPDATE = "UPDATE City SET Description = @Description WHERE Id = @Id";
        
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DtRegister { get; set; }
        public override string ToString()
        {
            return $"Id";
        }
    }
}