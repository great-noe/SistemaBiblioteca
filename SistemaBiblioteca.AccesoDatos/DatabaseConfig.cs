using MySqlConnector;
using Microsoft.EntityFrameworkCore;

namespace SistemaBiblioteca.AccesoDatos
{
    public static class DatabaseConfig
    {
        public static string ConnectionString => "server=localhost;database=BibliotecaDB;user=root;password=12345678";

        public static MySqlServerVersion GetServerVersion()
        {
            return new MySqlServerVersion(new Version(8, 0, 31));
        }
    }
}
