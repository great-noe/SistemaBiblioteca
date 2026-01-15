using SistemaBiblioteca.Entidades;

namespace SistemaBiblioteca.LogicaNegocio.Extensions
{
    public static class LibroExtensions
    {
        // Verifica si el libro tiene ejemplares para prestar
        public static bool TieneDisponibilidad(this Libro libro)
        {
            return libro.Activo && libro.CantidadDisponible > 0;
        }

        // Retorna un texto formateado para mostrar en listas de la interfaz
        public static string FormatoLista(this Libro libro)
        {
            return $"{libro.Titulo} - {libro.ISBN} ({libro.CantidadDisponible} disponibles)";
        }
    }
}
