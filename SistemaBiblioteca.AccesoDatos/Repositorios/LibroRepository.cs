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

        public List<Libro> ObtenerTodos()
        {
            return _context.Libros.Include(l => l.Categoria).ToList();
        }

        public void Insertar(Libro libro)
        {
            if (string.IsNullOrWhiteSpace(libro.ISBN))
                throw new Exception("El ISBN es obligatorio");

            var isbnExistente = _context.Libros
                .FirstOrDefault(l => l.ISBN == libro.ISBN);
            
            if (isbnExistente != null)
                throw new Exception("Ya existe un libro con ese ISBN");

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

        public Libro? ObtenerPorId(int id)
        {
            return _context.Libros
                .Include(l => l.Categoria)
                .FirstOrDefault(l => l.IdLibro == id);
        }

        public void Actualizar(Libro libro)
        {
            _context.Libros.Update(libro);
            _context.SaveChanges();
        }

        public void ActualizarStock(int idLibro, int cambio)
        {
            var libro = ObtenerPorId(idLibro);
            if (libro == null)
                throw new Exception("Libro no encontrado");

            libro.CantidadDisponible += cambio;

            if (libro.CantidadDisponible < 0)
                throw new Exception("Stock no puede ser negativo");

            if (libro.CantidadDisponible > libro.CantidadTotal)
                throw new Exception("Stock disponible no puede ser mayor al total");

            Actualizar(libro);
        }

        public void ActualizarEstadoFisico(int idLibro, string nuevoEstado)
        {
            var libro = ObtenerPorId(idLibro);
            if (libro == null)
                throw new Exception("Libro no encontrado");

            libro.EstadoFisico = nuevoEstado;
            Actualizar(libro);
        }

        public List<Libro> BuscarPorTermino(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return new List<Libro>();

            termino = termino.ToLower();

            return _context.Libros
                .Include(l => l.Categoria)
                .Include(l => l.LibroAutores)
                    .ThenInclude(la => la.Autor)
                .Where(l => 
                    l.Titulo.ToLower().Contains(termino) ||
                    l.ISBN.ToLower().Contains(termino) ||
                    (l.LibroAutores != null && l.LibroAutores.Any(la => la.Autor != null && (la.Autor.Nombre.ToLower().Contains(termino) ||
                                            la.Autor.Apellido.ToLower().Contains(termino)))) ||
                    (l.Categoria != null && l.Categoria.NombreCategoria.ToLower().Contains(termino)))
                .OrderBy(l => l.Titulo)
                .ToList();
        }

        public DateTime? ObtenerFechaEstimadaDisponibilidad(int idLibro)
        {
            var prestamos = _context.Prestamos
                .Where(p => p.IdLibro == idLibro && p.EstadoPrestamo == "Activo")
                .OrderBy(p => p.FechaDevolucionEstimada)
                .ToList();

            return prestamos.FirstOrDefault()?.FechaDevolucionEstimada;
        }
    }
}
