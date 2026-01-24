using SistemaBiblioteca.Entidades;
using SistemaBiblioteca.AccesoDatos.Repositorios;
using SistemaBiblioteca.AccesoDatos.Contexto;

namespace SistemaBiblioteca.PruebasConsola
{
    public static class PruebaRegistrarDevolucion
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║    HU-09: REGISTRAR DEVOLUCION - PRUEBA COMPLETA          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            try
            {
                var context = ContextHelper.CrearContexto();
                var prestamoRepo = new PrestamoRepository(context);
                var libroRepo = new LibroRepository(context);
                
                bool continuar = true;
                
                while (continuar)
                {
                    Console.WriteLine("═══ REGISTRAR DEVOLUCION ═══");
                    Console.WriteLine();
                    
                    // Obtener y mostrar prestamos activos
                    var prestamosActivos = prestamoRepo.ObtenerPrestamosActivos();
                    
                    if (prestamosActivos.Count == 0)
                    {
                        Console.WriteLine("❌ ERROR: No hay prestamos activos");
                        Console.WriteLine("   Debe registrar prestamos primero (Opcion 2 del menu)");
                        break;
                    }
                    
                    Console.WriteLine("PRESTAMOS ACTIVOS:");
                    Console.WriteLine("──────────────────");
                    foreach (var p in prestamosActivos)
                    {
                        var diasTranscurridos = (DateTime.Now - p.FechaPrestamo).Days;
                        var diasRestantes = (p.FechaDevolucionEstimada - DateTime.Now).Days;
                        string estado = diasRestantes < 0 ? "⚠️ ATRASADO" : "✅ EN TIEMPO";
                        
                        Console.WriteLine($"  ID: {p.IdPrestamo}");
                        Console.WriteLine($"      Usuario: {p.Usuario?.Nombre} {p.Usuario?.Apellido}");
                        Console.WriteLine($"      Libro: {p.Libro?.Titulo}");
                        Console.WriteLine($"      Fecha Prestamo: {p.FechaPrestamo:dd/MM/yyyy}");
                        Console.WriteLine($"      Fecha Devolucion Estimada: {p.FechaDevolucionEstimada:dd/MM/yyyy}");
                        Console.WriteLine($"      Dias transcurridos: {diasTranscurridos}");
                        Console.WriteLine($"      Estado: {estado}");
                        Console.WriteLine();
                    }
                    
                    Console.Write("Ingrese ID del Prestamo a devolver: ");
                    if (!int.TryParse(Console.ReadLine(), out int idPrestamo))
                    {
                        Console.WriteLine("❌ ERROR: ID invalido");
                        continue;
                    }
                    
                    var prestamo = prestamoRepo.ObtenerPorId(idPrestamo);
                    
                    if (prestamo == null)
                    {
                        Console.WriteLine("❌ ERROR: Prestamo no encontrado");
                        continue;
                    }
                    
                    if (prestamo.EstadoPrestamo != "Activo")
                    {
                        Console.WriteLine("❌ ERROR: El prestamo no esta activo");
                        Console.WriteLine($"   Estado actual: {prestamo.EstadoPrestamo}");
                        continue;
                    }
                    
                    Console.WriteLine();
                    Console.Write("Confirmar devolucion? (S/N): ");
                    string confirmacion = Console.ReadLine()?.ToUpper() ?? "N";
                    
                    if (confirmacion != "S")
                    {
                        Console.WriteLine("Devolucion cancelada.");
                        continue;
                    }
                    
                    Console.WriteLine();
                    
                    Console.WriteLine("Estado del libro devuelto:");
                    Console.WriteLine("  1. Bueno");
                    Console.WriteLine("  2. Regular");
                    Console.WriteLine("  3. Danado");
                    Console.WriteLine("  4. Perdido");
                    Console.Write("Opcion: ");
                    
                    string estadoLibro = "Bueno";
                    string opcionEstado = Console.ReadLine() ?? "1";
                    
                    switch (opcionEstado)
                    {
                        case "1":
                            estadoLibro = "Bueno";
                            break;
                        case "2":
                            estadoLibro = "Regular";
                            break;
                        case "3":
                            estadoLibro = "Dañado";
                            break;
                        case "4":
                            estadoLibro = "Perdido";
                            break;
                        default:
                            estadoLibro = "Bueno";
                            break;
                    }
                    
                    string? observacionesEstado = null;
                    if (estadoLibro != "Bueno")
                    {
                        Console.Write("Observaciones: ");
                        observacionesEstado = Console.ReadLine();
                    }
                    
                    Console.WriteLine();
                    
                    prestamoRepo.RegistrarDevolucion(idPrestamo, estadoLibro, observacionesEstado);
                    
                    prestamo = prestamoRepo.ObtenerPorId(idPrestamo);
                    
                    Console.WriteLine("✅ Devolucion registrada exitosamente");
                    Console.WriteLine();
                    Console.WriteLine($"Fecha Devolucion: {prestamo!.FechaDevolucionReal:dd/MM/yyyy HH:mm:ss}");
                    Console.WriteLine($"Estado: {prestamo.EstadoPrestamo}");
                    Console.WriteLine($"Estado Libro: {prestamo.EstadoLibroDevuelto}");
                    if (prestamo.MontoMulta > 0)
                        Console.WriteLine($"Multa generada: ${prestamo.MontoMulta:F2}");
                    
                    Console.WriteLine();
                    Console.Write("Desea registrar otra devolucion? (S/N): ");
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
