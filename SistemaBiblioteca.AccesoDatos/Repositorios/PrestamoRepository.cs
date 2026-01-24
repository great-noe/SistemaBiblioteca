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
                .Include(p => p.Usuario)
                .Include(p => p.Libro)
                .Where(p => p.EstadoPrestamo == "Activo")
                .ToList();
        }

        public Prestamo? ObtenerPorId(int id) => _context.Prestamos
            .Include(p => p.Usuario)
            .Include(p => p.Libro)
            .FirstOrDefault(p => p.IdPrestamo == id);

        public void RegistrarPrestamo(Prestamo prestamo)
        {
            using var transaction = _context.Database.BeginTransaction();
            try 
            {
                var libro = _context.Libros.Find(prestamo.IdLibro);
                if (libro == null)
                    throw new Exception("Libro no encontrado");

                if (libro.CantidadDisponible <= 0)
                    throw new Exception("El libro no tiene stock disponible");

                var multasPendientes = _context.Multas
                    .Any(m => m.IdUsuario == prestamo.IdUsuario && m.Estado == "Pendiente");
                if (multasPendientes)
                    throw new Exception("El usuario tiene multas pendientes. Debe pagarlas antes de solicitar un prestamo.");

                _context.Prestamos.Add(prestamo);
                _context.SaveChanges();

                libro.CantidadDisponible -= 1;
                _context.Libros.Update(libro);
                _context.SaveChanges();

                transaction.Commit();
            }
            catch {
                transaction.Rollback();
                throw;
            }
        }

        public void Actualizar(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            _context.SaveChanges();
        }

        public List<Prestamo> ObtenerPrestamosPorUsuario(int idUsuario)
        {
            return _context.Prestamos
                .Include(p => p.Libro)
                .Where(p => p.IdUsuario == idUsuario && p.EstadoPrestamo == "Activo")
                .ToList();
        }

        public void RenovarPrestamo(int idPrestamo)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var prestamo = ObtenerPorId(idPrestamo);
                if (prestamo == null)
                    throw new Exception("Prestamo no encontrado");

                if (prestamo.EstadoPrestamo != "Activo")
                    throw new Exception("Solo se pueden renovar prestamos activos");

                var multasPendientes = _context.Multas
                    .Any(m => m.IdUsuario == prestamo.IdUsuario && m.Estado == "Pendiente");
                if (multasPendientes)
                    throw new Exception("No se puede renovar. El usuario tiene multas pendientes.");

                var reservasPendientes = _context.Reservas
                    .Any(r => r.IdLibro == prestamo.IdLibro && r.Estado == "Pendiente");
                if (reservasPendientes)
                    throw new Exception("No se puede renovar. Hay reservas pendientes para este libro.");

                var historial = _context.HistorialPrestamos
                    .FirstOrDefault(h => h.IdUsuario == prestamo.IdUsuario && 
                                         h.IdLibro == prestamo.IdLibro);

                int vecesRenovado = historial?.VecesRenovado ?? 0;
                if (vecesRenovado >= 1)
                    throw new Exception("El prestamo ya fue renovado. No se permite renovar mas de 1 vez.");

                prestamo.FechaDevolucionEstimada = DateTime.Now.AddDays(15);
                Actualizar(prestamo);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void RegistrarDevolucion(int idPrestamo, string estadoLibro, string? observaciones)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var prestamo = ObtenerPorId(idPrestamo);
                if (prestamo == null)
                    throw new Exception("Prestamo no encontrado");

                if (prestamo.EstadoPrestamo != "Activo")
                    throw new Exception("El prestamo no esta activo");

                prestamo.FechaDevolucionReal = DateTime.Now;
                prestamo.EstadoPrestamo = "Devuelto";
                prestamo.EstadoLibroDevuelto = estadoLibro;
                prestamo.ObservacionesEstado = observaciones;
                prestamo.NotificacionEnviada = true;

                if (prestamo.FechaDevolucionReal > prestamo.FechaDevolucionEstimada)
                {
                    prestamo.DiasRetraso = (prestamo.FechaDevolucionReal.Value - prestamo.FechaDevolucionEstimada).Days;
                    prestamo.MontoMulta = prestamo.DiasRetraso * 1.00m;
                }

                if (estadoLibro == "Regular")
                    prestamo.MontoMulta += 2.00m;
                else if (estadoLibro == "Dañado")
                    prestamo.MontoMulta += 5.00m;
                else if (estadoLibro == "Perdido")
                    prestamo.MontoMulta += prestamo.Libro?.CantidadTotal * 10.00m ?? 50.00m;

                Actualizar(prestamo);

                if (prestamo.MontoMulta > 0)
                {
                    var multa = new Multa
                    {
                        IdUsuario = prestamo.IdUsuario,
                        IdPrestamo = prestamo.IdPrestamo,
                        Monto = prestamo.MontoMulta,
                        FechaGeneracion = DateTime.Now,
                        Estado = "Pendiente",
                        Motivo = prestamo.DiasRetraso > 0 ? "Retraso" : "Dano en libro"
                    };
                    _context.Multas.Add(multa);
                    _context.SaveChanges();
                }

                if (estadoLibro != "Perdido")
                {
                    var libro = _context.Libros.Find(prestamo.IdLibro);
                    if (libro != null)
                    {
                        libro.CantidadDisponible += 1;
                        _context.Libros.Update(libro);
                        _context.SaveChanges();
                    }
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
