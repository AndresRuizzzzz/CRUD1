using System.Data.SqlClient;
namespace CRUD1.Data
{
    public class Conexion
    {
        private string SQLString = string.Empty;

        public Conexion() {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            SQLString = builder.GetSection("ConnectionStrings:SQLConnection").Value;
        }

        public string GetSQLString()
        {
            return SQLString;
        }
    }
}
