using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaBiblioteca.AccesoDatos.Repositorios
{
    public class HistorialPrestamoRepository
    {
        private readonly BibliotecaContext _context;

        public HistorialPrestamoRepository(BibliotecaContext context) => _context = context;

        public List<HistorialPrestamo> ObtenerTodos()
        {
            return _context.HistorialPrestamos
                .OrderByDescending(h => h.IdHistorial)
                .ToList();
        }

        public HistorialPrestamo? ObtenerPorId(int id)
        {
            return _context.HistorialPrestamos
                .FirstOrDefault(h => h.IdHistorial == id);
        }

        public List<HistorialPrestamo> ObtenerPorUsuario(int idUsuario)
        {
            return _context.HistorialPrestamos
                .Where(h => h.IdUsuario == idUsuario)
                .OrderByDescending(h => h.IdHistorial)
                .ToList();
        }

        public List<HistorialPrestamo> ObtenerPorLibro(int idLibro)
        {
            return _context.HistorialPrestamos
                .Where(h => h.IdLibro == idLibro)
                .OrderByDescending(h => h.IdHistorial)
                .ToList();
        }

        public void Insertar(HistorialPrestamo historial)
        {
            _context.HistorialPrestamos.Add(historial);
            _context.SaveChanges();
        }

        public void RegistrarDesdeDevolucion(Prestamo prestamo)
        {
            var historial = new HistorialPrestamo
            {
                IdUsuario = prestamo.IdUsuario,
                IdLibro = prestamo.IdLibro
            };

            Insertar(historial);
        }
    }
}
