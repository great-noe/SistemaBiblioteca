using SistemaBiblioteca.Entidades;
using SistemaBiblioteca.AccesoDatos.Repositorios;
using SistemaBiblioteca.AccesoDatos.Contexto;

namespace SistemaBiblioteca.PruebasConsola
{
    public static class PruebaReservarLibro
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║       HU-11: RESERVAR LIBRO - PRUEBA COMPLETA             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            try
            {
                var context = ContextHelper.CrearContexto();
                var libroRepo = new LibroRepository(context);
                var usuarioRepo = new UsuarioRepository(context);
                
                bool continuar = true;
                
                while (continuar)
                {
                    Console.WriteLine("═══ CREAR NUEVA RESERVA ═══");
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
                        Console.WriteLine($"  ID: {u.IdUsuario} - {u.Nombre} {u.Apellido}");
                    }
                    Console.WriteLine();
                    
                    Console.Write("Ingrese ID del Usuario: ");
                    if (!int.TryParse(Console.ReadLine(), out int idUsuario))
                    {
                        Console.WriteLine("❌ ERROR: ID invalido");
                        continue;
                    }
                    
                    // Mostrar todos los libros
                    var libros = libroRepo.ObtenerTodos();
                    if (libros.Count == 0)
                    {
                        Console.WriteLine("❌ ERROR: No hay libros registrados");
                        break;
                    }
                    
                    Console.WriteLine();
                    Console.WriteLine("CATALOGO DE LIBROS:");
                    Console.WriteLine("───────────────────");
                    foreach (var lib in libros)
                    {
                        string disponibilidad = lib.CantidadDisponible > 0 
                            ? $"✅ DISPONIBLE ({lib.CantidadDisponible} unidades)" 
                            : "❌ NO DISPONIBLE - Puede reservar";
                        Console.WriteLine($"  ID: {lib.IdLibro} - {lib.Titulo}");
                        Console.WriteLine($"       ISBN: {lib.ISBN}");
                        Console.WriteLine($"       Estado: {disponibilidad}");
                        Console.WriteLine();
                    }
                    
                    Console.Write("Ingrese ID del Libro a reservar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idLibro))
                    {
                        Console.WriteLine("❌ ERROR: ID invalido");
                        continue;
                    }
                    
                    Console.WriteLine();
                    
                    var reservaRepo = new ReservaRepository(context);
                    
                    var nuevaReserva = new Reserva
                    {
                        IdUsuario = idUsuario,
                        IdLibro = idLibro,
                        FechaReserva = DateTime.Now,
                        Estado = "Pendiente"
                    };
                    
                    reservaRepo.Insertar(nuevaReserva);
                    
                    Console.WriteLine("✅ Reserva creada exitosamente");
                    Console.WriteLine();
                    Console.WriteLine($"ID Reserva: {nuevaReserva.IdReserva}");
                    Console.WriteLine($"Fecha Reserva: {nuevaReserva.FechaReserva:dd/MM/yyyy HH:mm:ss}");
                    Console.WriteLine($"Estado: {nuevaReserva.Estado}");
                    Console.WriteLine($"Posicion en cola: {nuevaReserva.PosicionCola}");
                    
                    Console.WriteLine();
                    Console.Write("Desea crear otra reserva? (S/N): ");
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
