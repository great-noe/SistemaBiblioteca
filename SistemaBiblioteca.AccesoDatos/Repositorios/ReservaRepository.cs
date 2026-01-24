using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaBiblioteca.AccesoDatos.Repositorios
{
    public class ReservaRepository
    {
        private readonly BibliotecaContext _context;

        public ReservaRepository(BibliotecaContext context) => _context = context;

        public List<Reserva> ObtenerTodas()
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Libro)
                .ToList();
        }

        public Reserva? ObtenerPorId(int id)
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Libro)
                .FirstOrDefault(r => r.IdReserva == id);
        }

        public List<Reserva> ObtenerReservasPendientes(int idLibro)
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Where(r => r.IdLibro == idLibro && r.Estado == "Pendiente")
                .OrderBy(r => r.FechaReserva)
                .ToList();
        }

        public int ContarReservasActivas(int idUsuario)
        {
            return _context.Reservas
                .Count(r => r.IdUsuario == idUsuario && r.Estado == "Pendiente");
        }

        public void Insertar(Reserva reserva)
        {
            if (reserva.IdUsuario <= 0)
                throw new Exception("Usuario invalido");

            if (reserva.IdLibro <= 0)
                throw new Exception("Libro invalido");

            var reservasActivas = ContarReservasActivas(reserva.IdUsuario);
            if (reservasActivas >= 3)
                throw new Exception("El usuario ya tiene 3 reservas activas. No puede crear mas.");

            var libro = _context.Libros.Find(reserva.IdLibro);
            if (libro == null)
                throw new Exception("Libro no encontrado");

            if (libro.CantidadDisponible > 0)
                throw new Exception("El libro esta disponible. Realice un prestamo en lugar de una reserva.");

            var reservasPendientes = ObtenerReservasPendientes(reserva.IdLibro);
            reserva.PosicionCola = reservasPendientes.Count + 1;

            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        public void CancelarReserva(int idReserva)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var reserva = ObtenerPorId(idReserva);
                if (reserva == null)
                    throw new Exception("Reserva no encontrada");

                if (reserva.Estado != "Pendiente")
                    throw new Exception("Solo se pueden cancelar reservas pendientes");

                reserva.Estado = "Cancelada";
                reserva.FechaCancelacion = DateTime.Now;

                _context.Reservas.Update(reserva);
                _context.SaveChanges();

                ReorganizarCola(reserva.IdLibro);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private void ReorganizarCola(int idLibro)
        {
            var reservasPendientes = ObtenerReservasPendientes(idLibro);
            int posicion = 1;
            foreach (var reserva in reservasPendientes)
            {
                reserva.PosicionCola = posicion++;
                _context.Reservas.Update(reserva);
            }
            _context.SaveChanges();
        }

        public Reserva? ObtenerSiguienteEnCola(int idLibro)
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Where(r => r.IdLibro == idLibro && r.Estado == "Pendiente")
                .OrderBy(r => r.PosicionCola)
                .FirstOrDefault();
        }

        public void NotificarDisponibilidad(int idLibro)
        {
            var siguienteReserva = ObtenerSiguienteEnCola(idLibro);
            if (siguienteReserva != null)
            {
                siguienteReserva.Notificado = true;
                siguienteReserva.FechaNotificacion = DateTime.Now;
                _context.Reservas.Update(siguienteReserva);
                _context.SaveChanges();
            }
        }
    }
}
