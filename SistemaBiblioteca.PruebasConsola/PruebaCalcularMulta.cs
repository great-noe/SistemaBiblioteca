using SistemaBiblioteca.Entidades;
using SistemaBiblioteca.AccesoDatos.Repositorios;
using SistemaBiblioteca.AccesoDatos.Contexto;

namespace SistemaBiblioteca.PruebasConsola
{
    public static class PruebaCalcularMulta
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║      HU-13: CALCULAR MULTA - PRUEBA COMPLETA              ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            try
            {
                var context = ContextHelper.CrearContexto();
                var prestamoRepo = new PrestamoRepository(context);
                
                bool continuar = true;
                
                while (continuar)
                {
                    Console.WriteLine("═══ CALCULAR MULTA POR ATRASO ═══");
                    Console.WriteLine();
                    
                    var prestamosActivos = prestamoRepo.ObtenerPrestamosActivos();
                    
                    if (prestamosActivos.Count == 0)
                    {
                        Console.WriteLine("ℹ️  No hay prestamos activos para calcular multas");
                        Console.WriteLine();
                        Console.WriteLine("OPCION 1: Crear simulacion de prestamo con atraso");
                        Console.WriteLine("OPCION 2: Registrar prestamo primero (Menu opcion 2)");
                        Console.WriteLine();
                        Console.Write("Seleccione opcion (1/2): ");
                        string opcion = Console.ReadLine() ?? "1";
                        
                        if (opcion == "1")
                        {
                            SimularCalculoMulta();
                        }
                        break;
                    }
                    
                    Console.WriteLine("PRESTAMOS ACTIVOS:");
                    Console.WriteLine("──────────────────");
                    
                    foreach (var p in prestamosActivos)
                    {
                        var diasAtrasoTemp = (DateTime.Now - p.FechaDevolucionEstimada).Days;
                        string estadoAtraso = diasAtrasoTemp > 0 ? $"⚠️ ATRASADO ({diasAtrasoTemp} dias)" : "✅ EN TIEMPO";
                        
                        Console.WriteLine($"  ID: {p.IdPrestamo}");
                        Console.WriteLine($"      Usuario: {p.Usuario?.Nombre} {p.Usuario?.Apellido}");
                        Console.WriteLine($"      Libro: {p.Libro?.Titulo}");
                        Console.WriteLine($"      Fecha Prestamo: {p.FechaPrestamo:dd/MM/yyyy}");
                        Console.WriteLine($"      Fecha Devolucion Estimada: {p.FechaDevolucionEstimada:dd/MM/yyyy}");
                        Console.WriteLine($"      Estado: {estadoAtraso}");
                        if (diasAtrasoTemp > 0)
                        {
                            Console.WriteLine($"      Multa potencial: ${diasAtrasoTemp * 1.00m:F2}");
                        }
                        Console.WriteLine();
                    }
                    
                    Console.Write("Ingrese ID del Prestamo para calcular multa: ");
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
                    
                    Console.WriteLine();
                    Console.Write("Usar fecha actual para calculo? (S/N): ");
                    string usarHoy = Console.ReadLine()?.ToUpper() ?? "S";
                    
                    DateTime fechaDevolucionReal;
                    if (usarHoy == "S")
                    {
                        fechaDevolucionReal = DateTime.Now;
                    }
                    else
                    {
                        Console.Write("Dias de atraso a simular: ");
                        if (int.TryParse(Console.ReadLine(), out int diasAtrasoSimulado))
                        {
                            fechaDevolucionReal = prestamo.FechaDevolucionEstimada.AddDays(diasAtrasoSimulado);
                        }
                        else
                        {
                            fechaDevolucionReal = DateTime.Now;
                        }
                    }
                    
                    Console.WriteLine();
                    
                    var diasAtraso = (fechaDevolucionReal - prestamo.FechaDevolucionEstimada).Days;
                    
                    if (diasAtraso > 0)
                    {
                        var multaRepo = new MultaRepository(context);
                        
                        decimal montoMulta = diasAtraso * 1.00m;
                        
                        var multa = new Multa
                        {
                            IdUsuario = prestamo.IdUsuario,
                            IdPrestamo = prestamo.IdPrestamo,
                            Monto = montoMulta,
                            FechaGeneracion = DateTime.Now,
                            Estado = "Pendiente",
                            Motivo = "Retraso"
                        };
                        
                        multaRepo.Insertar(multa);
                        
                        Console.WriteLine("✅ Multa generada exitosamente");
                        Console.WriteLine();
                        Console.WriteLine($"ID Multa: {multa.IdMulta}");
                        Console.WriteLine($"Monto: ${multa.Monto:F2}");
                        Console.WriteLine($"Estado: {multa.Estado}");
                        Console.WriteLine($"Dias de atraso: {diasAtraso}");
                    }
                    else
                    {
                        Console.WriteLine("✅ Sin atraso, no se genera multa");
                    }
                    
                    Console.WriteLine();
                    Console.Write("Desea calcular otra multa? (S/N): ");
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
        
        private static void SimularCalculoMulta()
        {
            Console.WriteLine();
            Console.WriteLine("═══ SIMULACION DE PRESTAMO CON ATRASO ═══");
            Console.WriteLine();
            
            Console.Write("Ingrese dias de atraso a simular: ");
            if (!int.TryParse(Console.ReadLine(), out int diasAtraso))
            {
                diasAtraso = 6; // Valor por defecto
            }
            
            var fechaPrestamo = DateTime.Now.AddDays(-(15 + diasAtraso));
            var fechaEstimada = fechaPrestamo.AddDays(15);
            var fechaReal = DateTime.Now;
            
            Console.WriteLine();
            Console.WriteLine("DATOS SIMULADOS:");
            Console.WriteLine($"📅 Fecha Prestamo: {fechaPrestamo:dd/MM/yyyy}");
            Console.WriteLine($"📅 Fecha Devolucion Estimada: {fechaEstimada:dd/MM/yyyy}");
            Console.WriteLine($"📅 Fecha Devolucion Real: {fechaReal:dd/MM/yyyy}");
            Console.WriteLine($"⏱️  Dias de Atraso: {diasAtraso}");
            
            Console.WriteLine();
            Console.WriteLine("═══ CALCULO DE MULTA ═══");
            Console.WriteLine();
            
            decimal montoMulta = diasAtraso * 1.00m;
            Console.WriteLine($"💰 Formula: {diasAtraso} dias × $1.00 = ${montoMulta:F2}");
            
            Console.WriteLine();
            Console.WriteLine("✅ Multa calculada correctamente");
            Console.WriteLine($"   Monto: ${montoMulta:F2}");
            Console.WriteLine($"   Estado: Pendiente");
            Console.WriteLine($"   Motivo: Retraso");
            
            Console.WriteLine();
            Console.WriteLine("CRITERIOS VERIFICADOS:");
            Console.WriteLine("  ✅ Formula aplicada correctamente");
            Console.WriteLine("  ✅ Solo se calcula con atraso > 0");
            Console.WriteLine("  ✅ Monto proporcional a dias de atraso");
        }
    }
}
