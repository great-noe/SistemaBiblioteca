public class AutorRepository
{
    private readonly BibliotecaContext _context;
    public AutorRepository(BibliotecaContext context) => _context = context;

    public List<Autor> ObtenerTodos() => _context.Autores.ToList();
    public void Insertar(Autor autor) { _context.Autores.Add(autor); _context.SaveChanges(); }
}
