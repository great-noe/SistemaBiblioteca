using SistemaBiblioteca.Entidades;
using SistemaBiblioteca.AccesoDatos.Repositorios;
using SistemaBiblioteca.AccesoDatos.Contexto;

namespace SistemaBiblioteca.PruebasConsola
{
    public static class PruebaRegistrarPrestamo
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║      HU-08: REGISTRAR PRESTAMO - PRUEBA COMPLETA          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            try
            {
                var context = ContextHelper.CrearContexto();
                var prestamoRepo = new PrestamoRepository(context);
                var libroRepo = new LibroRepository(context);
                var usuarioRepo = new UsuarioRepository(context);
                
                bool continuar = true;
                
                while (continuar)
                {
                    Console.WriteLine("═══ REGISTRAR NUEVO PRESTAMO ═══");
                    Console.WriteLine();
                    
                    // Mostrar usuarios disponibles
                    var usuarios = usuarioRepo.ObtenerTodos();
                    if (usuarios.Count == 0)
                    {
                        Console.WriteLine("❌ ERROR: No hay usuarios registrados");
                        Console.WriteLine("   Debe registrar usuarios primero (Opcion 1 del menu)");
                        break;
                    }
                    
                    Console.WriteLine("USUARIOS DISPONIBLES:");
                    Console.WriteLine("─────────────────────");
                    foreach (var u in usuarios)
                    {
                        Console.WriteLine($"  ID: {u.IdUsuario} - {u.Nombre} {u.Apellido} ({u.NumeroIdentificacion})");
                    }
                    Console.WriteLine();
                    
                    Console.Write("Ingrese ID del Usuario: ");
                    if (!int.TryParse(Console.ReadLine(), out int idUsuario))
                    {
                        Console.WriteLine("❌ ERROR: ID invalido");
                        continue;
                    }
                    
                    // Mostrar libros disponibles
                    var libros = libroRepo.ObtenerTodos();
                    if (libros.Count == 0)
                    {
                        Console.WriteLine("❌ ERROR: No hay libros registrados");
                        Console.WriteLine("   Debe insertar libros en la base de datos");
                        break;
                    }
                    
                    Console.WriteLine();
                    Console.WriteLine("LIBROS DISPONIBLES:");
                    Console.WriteLine("───────────────────");
                    foreach (var lib in libros)
                    {
                        string disponibilidad = lib.CantidadDisponible > 0 ? "✅ DISPONIBLE" : "❌ NO DISPONIBLE";
                        Console.WriteLine($"  ID: {lib.IdLibro} - {lib.Titulo}");
                        Console.WriteLine($"       ISBN: {lib.ISBN}");
                        Console.WriteLine($"       Stock: {lib.CantidadDisponible}/{lib.CantidadTotal} - {disponibilidad}");
                        Console.WriteLine();
                    }
                    
                    Console.Write("Ingrese ID del Libro: ");
                    if (!int.TryParse(Console.ReadLine(), out int idLibro))
                    {
                        Console.WriteLine("❌ ERROR: ID invalido");
                        continue;
                    }
                    
                    Console.WriteLine();
                    
                    var nuevoPrestamo = new Prestamo
                    {
                        IdUsuario = idUsuario,
                        IdLibro = idLibro,
                        FechaPrestamo = DateTime.Now,
                        FechaDevolucionEstimada = DateTime.Now.AddDays(15),
                        EstadoPrestamo = "Activo"
                    };
                    
                    prestamoRepo.RegistrarPrestamo(nuevoPrestamo);
                    
                    Console.WriteLine("✅ Prestamo registrado exitosamente");
                    Console.WriteLine();
                    Console.WriteLine($"ID Prestamo: {nuevoPrestamo.IdPrestamo}");
                    Console.WriteLine($"Fecha Prestamo: {nuevoPrestamo.FechaPrestamo:dd/MM/yyyy}");
                    Console.WriteLine($"Fecha Devolucion Estimada: {nuevoPrestamo.FechaDevolucionEstimada:dd/MM/yyyy}");
                    Console.WriteLine($"Estado: {nuevoPrestamo.EstadoPrestamo}");
                    
                    Console.WriteLine();
                    Console.Write("Desea registrar otro prestamo? (S/N): ");
                    string respuesta = Console.ReadLine()?.ToUpper() ?? "N";
                    continuar = (respuesta == "S");
                    
                    if (continuar)
                        Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("❌ ERROR EN LA PRUEBA:");
                Console.WriteLine($"   {ex.Message}");
                Console.WriteLine();
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"   Error interno: {ex.InnerException.Message}");
                }
            }
        }
    }
}
