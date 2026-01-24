using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaBiblioteca.AccesoDatos.Repositorios
{
    public class CategoriaRepository
    {
        private readonly BibliotecaContext _context;
        
        public CategoriaRepository(BibliotecaContext context) => _context = context;

        public List<Categoria> ObtenerTodas() => _context.Categorias.Where(c => c.Activo).ToList();
        
        public Categoria? ObtenerPorId(int id) => _context.Categorias.FirstOrDefault(c => c.IdCategoria == id);
        
        public void Insertar(Categoria categoria) 
        { 
            _context.Categorias.Add(categoria); 
            _context.SaveChanges(); 
        }
        
        public void Actualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }
        
        public void Eliminar(int id)
        {
            var categoria = ObtenerPorId(id);
            if (categoria != null)
            {
                categoria.Activo = false;
                _context.SaveChanges();
            }
        }
    }
}
