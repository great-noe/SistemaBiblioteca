using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaBiblioteca.AccesoDatos.Repositorios
{
    public class LibroRepository
    {
        private readonly BibliotecaContext _context;

        public LibroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        // Método ObtenerTodos()
        public List<Libro> ObtenerTodos()
        {
            return _context.Libros.Include(l => l.Categoria).ToList();
        }

        public void Insertar(Libro libro)
        {

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    _context.Libros.Add(libro);
                    _context.SaveChanges();
                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
