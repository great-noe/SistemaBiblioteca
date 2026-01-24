using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaBiblioteca.AccesoDatos.Repositorios
{
    public class MultaRepository
    {
        private readonly BibliotecaContext _context;

        public MultaRepository(BibliotecaContext context) => _context = context;

        public List<Multa> ObtenerTodas()
        {
            return _context.Multas
                .Include(m => m.Usuario)
                .Include(m => m.Prestamo)
                .ToList();
        }

        public Multa? ObtenerPorId(int id)
        {
            return _context.Multas
                .Include(m => m.Usuario)
                .Include(m => m.Prestamo)
                .FirstOrDefault(m => m.IdMulta == id);
        }

        public List<Multa> ObtenerPorUsuario(int idUsuario)
        {
            return _context.Multas
                .Include(m => m.Prestamo)
                .Where(m => m.IdUsuario == idUsuario)
                .OrderByDescending(m => m.FechaGeneracion)
                .ToList();
        }

        public List<Multa> ObtenerMultasPendientes(int idUsuario)
        {
            return _context.Multas
                .Where(m => m.IdUsuario == idUsuario && m.Estado == "Pendiente")
                .ToList();
        }

        public void Insertar(Multa multa)
        {
            _context.Multas.Add(multa);
            _context.SaveChanges();
        }

        public void RegistrarPago(int idMulta, decimal montoPagado, string metodoPago)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var multa = ObtenerPorId(idMulta);
                if (multa == null)
                    throw new Exception("Multa no encontrada");

                if (multa.Estado == "Pagada")
                    throw new Exception("La multa ya esta pagada");

                multa.Estado = "Pagada";
                multa.FechaPago = DateTime.Now;

                _context.Multas.Update(multa);
                _context.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool TieneMultasPendientes(int idUsuario)
        {
            return _context.Multas
                .Any(m => m.IdUsuario == idUsuario && m.Estado == "Pendiente");
        }

        public decimal ObtenerTotalMultasPendientes(int idUsuario)
        {
            return _context.Multas
                .Where(m => m.IdUsuario == idUsuario && m.Estado == "Pendiente")
                .Sum(m => m.Monto);
        }
    }
}
