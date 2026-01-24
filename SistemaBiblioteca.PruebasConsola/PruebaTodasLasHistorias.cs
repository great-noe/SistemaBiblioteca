using SistemaBiblioteca.Entidades;
using SistemaBiblioteca.AccesoDatos.Repositorios;
using SistemaBiblioteca.AccesoDatos.Contexto;

namespace SistemaBiblioteca.PruebasConsola
{
    public static class PruebaTodasLasHistorias
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║      EJECUTAR TODAS LAS PRUEBAS - SUITE COMPLETA          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("Esta prueba ejecutara todas las historias de usuario en orden:");
            Console.WriteLine("  1. HU-01: Registrar Usuario");
            Console.WriteLine("  2. HU-08: Registrar Prestamo");
            Console.WriteLine("  3. HU-09: Registrar Devolucion");
            Console.WriteLine("  4. HU-11: Reservar Libro");
            Console.WriteLine("  5. HU-13: Calcular Multa");
            Console.WriteLine();
            Console.Write("¿Desea continuar? (S/N): ");
            
            var respuesta = Console.ReadLine()?.ToUpper();
            if (respuesta != "S")
            {
                Console.WriteLine("Prueba cancelada.");
                return;
            }
            
            var resultados = new List<(string Historia, bool Exito, string Mensaje)>();
            
            // HU-01: Registrar Usuario
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("EJECUTANDO HU-01: REGISTRAR USUARIO");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
            
            try
            {
                PruebaRegistrarUsuario.Ejecutar();
                resultados.Add(("HU-01: Registrar Usuario", true, "Exitosa"));
            }
            catch (Exception ex)
            {
                resultados.Add(("HU-01: Registrar Usuario", false, ex.Message));
            }
            
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar con la siguiente prueba...");
            Console.ReadKey();
            
            // HU-08: Registrar Prestamo
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("EJECUTANDO HU-08: REGISTRAR PRESTAMO");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
            
            try
            {
                PruebaRegistrarPrestamo.Ejecutar();
                resultados.Add(("HU-08: Registrar Prestamo", true, "Exitosa"));
            }
            catch (Exception ex)
            {
                resultados.Add(("HU-08: Registrar Prestamo", false, ex.Message));
            }
            
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar con la siguiente prueba...");
            Console.ReadKey();
            
            // HU-09: Registrar Devolucion
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("EJECUTANDO HU-09: REGISTRAR DEVOLUCION");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
            
            try
            {
                PruebaRegistrarDevolucion.Ejecutar();
                resultados.Add(("HU-09: Registrar Devolucion", true, "Exitosa"));
            }
            catch (Exception ex)
            {
                resultados.Add(("HU-09: Registrar Devolucion", false, ex.Message));
            }
            
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar con la siguiente prueba...");
            Console.ReadKey();
            
            // HU-11: Reservar Libro
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("EJECUTANDO HU-11: RESERVAR LIBRO");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
            
            try
            {
                PruebaReservarLibro.Ejecutar();
                resultados.Add(("HU-11: Reservar Libro", true, "Exitosa"));
            }
            catch (Exception ex)
            {
                resultados.Add(("HU-11: Reservar Libro", false, ex.Message));
            }
            
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar con la siguiente prueba...");
            Console.ReadKey();
            
            // HU-13: Calcular Multa
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("EJECUTANDO HU-13: CALCULAR MULTA");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
            
            try
            {
                PruebaCalcularMulta.Ejecutar();
                resultados.Add(("HU-13: Calcular Multa", true, "Exitosa"));
            }
            catch (Exception ex)
            {
                resultados.Add(("HU-13: Calcular Multa", false, ex.Message));
            }
            
            // Resumen final
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           RESUMEN DE PRUEBAS - SUITE COMPLETA             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            int exitosas = resultados.Count(r => r.Exito);
            int fallidas = resultados.Count(r => !r.Exito);
            
            Console.WriteLine($"Total de pruebas ejecutadas: {resultados.Count}");
            Console.WriteLine($"Pruebas exitosas: {exitosas}");
            Console.WriteLine($"Pruebas fallidas: {fallidas}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine();
            
            foreach (var resultado in resultados)
            {
                string icono = resultado.Exito ? "✅" : "❌";
                Console.WriteLine($"{icono} {resultado.Historia}");
                if (!resultado.Exito)
                {
                    Console.WriteLine($"   Error: {resultado.Mensaje}");
                }
            }
            
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
            
            if (exitosas == resultados.Count)
            {
                Console.WriteLine("🎉 TODAS LAS PRUEBAS FUERON EXITOSAS 🎉");
            }
            else
            {
                Console.WriteLine($"⚠️  {fallidas} PRUEBA(S) FALLARON");
            }
            
            Console.WriteLine();
            Console.WriteLine("Porcentaje de exito: {0:F2}%", (exitosas * 100.0 / resultados.Count));
        }
    }
}
