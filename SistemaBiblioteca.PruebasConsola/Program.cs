using SistemaBiblioteca.Entidades;
using SistemaBiblioteca.AccesoDatos.Repositorios;
using SistemaBiblioteca.AccesoDatos.Contexto;

namespace SistemaBiblioteca.PruebasConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            bool salir = false;
            
            while (!salir)
            {
                MostrarMenuPrincipal();
                string opcion = Console.ReadLine() ?? "";
                
                switch (opcion)
                {
                    case "1":
                        PruebaRegistrarUsuario.Ejecutar();
                        break;
                    case "2":
                        PruebaRegistrarPrestamo.Ejecutar();
                        break;
                    case "3":
                        PruebaRegistrarDevolucion.Ejecutar();
                        break;
                    case "4":
                        PruebaReservarLibro.Ejecutar();
                        break;
                    case "5":
                        PruebaCalcularMulta.Ejecutar();
                        break;
                    case "0":
                        salir = true;
                        Console.WriteLine("\n¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalida. Intente nuevamente.");
                        break;
                }
                
                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
        
        static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   SISTEMA BIBLIOTECA - PRUEBAS DE HISTORIAS DE USUARIO    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("  1. HU-01: Registrar Usuario");
            Console.WriteLine("  2. HU-08: Registrar Prestamo");
            Console.WriteLine("  3. HU-09: Registrar Devolucion");
            Console.WriteLine("  4. HU-11: Reservar Libro");
            Console.WriteLine("  5. HU-13: Calcular Multa");
            Console.WriteLine();
            Console.WriteLine("  0. Salir");
            Console.WriteLine();
            Console.Write("Seleccione una opcion: ");
        }
    }
}
