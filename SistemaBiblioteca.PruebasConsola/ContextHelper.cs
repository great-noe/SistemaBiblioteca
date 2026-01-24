using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.AccesoDatos.Contexto;

namespace SistemaBiblioteca.PruebasConsola
{
    public static class ContextHelper
    {
        public static BibliotecaContext CrearContexto()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BibliotecaContext>();
            optionsBuilder.UseMySql(
                "server=localhost;database=bibliotecadb;user=root;password=12345678",
                new MySqlServerVersion(new Version(8, 0, 31))
            );
            
            return new BibliotecaContext(optionsBuilder.Options);
        }
    }
}
