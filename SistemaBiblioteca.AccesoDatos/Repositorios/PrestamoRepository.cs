using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaBiblioteca.AccesoDatos.Repositorios
{
    public class PrestamoRepository
    {
        private readonly BibliotecaContext _context;

        public PrestamoRepository(BibliotecaContext context) => _context = context;

        public List<Prestamo> ObtenerPrestamosActivos()
        {
            return _context.Prestamos
                .Include(p => p.IdUsuario) // Trae datos del usuario
                .Include(p => p.IdLibro)   // Trae datos del libro
                .Where(p => p.EstadoPrestamo == "Activo")
                .ToList();
        }

        public void RegistrarPrestamo(Prestamo prestamo)
        {
            // El bloque 'using' o la transacción asegura que si algo falla, no se guarde nada parcial
            using var transaction = _context.Database.BeginTransaction();
            try 
            {
                _context.Prestamos.Add(prestamo);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch {
                transaction.Rollback();
                throw;
            }
        }
    }
}
