using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Entidades;

namespace SistemaBiblioteca.AccesoDatos.Contexto
{
    public class BibliotecaContext : DbContext
    {
        // Constructor para pasar opciones (cadena de conexión)
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options) { }

        // Definir los DbSets (Tablas)
        public DbSet<Autor> Autores { get; set; }
        // Aquí agregarás los demás: Libros, Prestamos, etc.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales si son necesarias
            base.OnModelCreating(modelBuilder);
        }
    }
}