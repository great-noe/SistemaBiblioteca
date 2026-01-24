using SistemaBiblioteca.Entidades;

namespace SistemaBiblioteca.LogicaNegocio.Extensions
{
    public static class LibroExtensions
    {
        public static bool TieneDisponibilidad(this Libro libro)
        {
            return libro.Activo && libro.CantidadDisponible > 0;
        }

        public static string FormatoLista(this Libro libro)
        {
            return $"{libro.Titulo} - {libro.ISBN} ({libro.CantidadDisponible} disponibles)";
        }
    }
}
