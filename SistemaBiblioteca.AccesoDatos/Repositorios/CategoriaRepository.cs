using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;

public class CategoriaRepository
{
    private readonly BibliotecaContext _context;
    public CategoriaRepository(BibliotecaContext context) => _context = context;

    public List<Categoria> ObtenerActivas() => _context.Categorias.Where(c => c.Activo).ToList();
}

