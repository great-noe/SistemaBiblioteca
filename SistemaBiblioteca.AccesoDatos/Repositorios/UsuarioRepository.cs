using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaBiblioteca.AccesoDatos.Repositorios
{
    public class UsuarioRepository
    {
        private readonly BibliotecaContext _context;

        public UsuarioRepository(BibliotecaContext context) => _context = context;

        public List<Usuario> ObtenerTodos() 
        {
            return _context.Usuarios.Where(u => u.Activo).ToList();
        }

        public Usuario? ObtenerPorIdentificacion(string numeroIdentificacion)
        {
            // Usamos parámetros automáticos de EF para prevenir Inyección SQL
            return _context.Usuarios.FirstOrDefault(u => u.NumeroIdentificacion == numeroIdentificacion);
        }

        public void Insertar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}
