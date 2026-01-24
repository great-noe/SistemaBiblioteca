using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaBiblioteca.AccesoDatos.Repositorios
{
    public class AutorRepository
    {
        private readonly BibliotecaContext _context;
        
        public AutorRepository(BibliotecaContext context) => _context = context;

        public List<Autor> ObtenerTodos() => _context.Autores.Where(a => a.Activo).ToList();
        
        public Autor? ObtenerPorId(int id) => _context.Autores.FirstOrDefault(a => a.IdAutor == id);
        
        public void Insertar(Autor autor) 
        { 
            _context.Autores.Add(autor); 
            _context.SaveChanges(); 
        }
        
        public void Actualizar(Autor autor)
        {
            _context.Autores.Update(autor);
            _context.SaveChanges();
        }
        
        public void Eliminar(int id)
        {
            var autor = ObtenerPorId(id);
            if (autor != null)
            {
                autor.Activo = false;
                _context.SaveChanges();
            }
        }
    }
}
