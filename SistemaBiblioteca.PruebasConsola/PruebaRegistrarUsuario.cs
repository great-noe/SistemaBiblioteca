using SistemaBiblioteca.Entidades;
using SistemaBiblioteca.AccesoDatos.Repositorios;
using SistemaBiblioteca.AccesoDatos.Contexto;

namespace SistemaBiblioteca.PruebasConsola
{
    public static class PruebaRegistrarUsuario
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║       HU-01: REGISTRAR USUARIO - PRUEBA COMPLETA          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            try
            {
                var context = ContextHelper.CrearContexto();
                var usuarioRepo = new UsuarioRepository(context);
                
                bool continuar = true;
                
                while (continuar)
                {
                    Console.WriteLine("═══ REGISTRAR NUEVO USUARIO ═══");
                    Console.WriteLine();
                    
                    // Solicitar datos al usuario
                    Console.Write("Ingrese Nombre: ");
                    string nombre = Console.ReadLine() ?? "";
                    
                    Console.Write("Ingrese Apellido: ");
                    string apellido = Console.ReadLine() ?? "";
                    
                    Console.Write("Ingrese Numero de Identificacion: ");
                    string numeroIdentificacion = Console.ReadLine() ?? "";
                    
                    Console.Write("Ingrese Email: ");
                    string email = Console.ReadLine() ?? "";
                    
                    Console.Write("Ingrese Telefono: ");
                    string telefono = Console.ReadLine() ?? "";
                    
                    Console.Write("Ingrese Direccion: ");
                    string direccion = Console.ReadLine() ?? "";
                    
                    Console.WriteLine();
                    
                    var nuevoUsuario = new Usuario
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        NumeroIdentificacion = numeroIdentificacion,
                        Email = email,
                        Telefono = telefono,
                        Direccion = direccion,
                        Activo = true,
                        FechaRegistro = DateTime.Now
                    };
                    
                    usuarioRepo.Insertar(nuevoUsuario);
                    
                    Console.WriteLine("✅ Usuario registrado exitosamente");
                    Console.WriteLine();
                    Console.WriteLine($"ID: {nuevoUsuario.IdUsuario}");
                    Console.WriteLine($"Nombre: {nuevoUsuario.Nombre} {nuevoUsuario.Apellido}");
                    Console.WriteLine($"Identificacion: {nuevoUsuario.NumeroIdentificacion}");
                    Console.WriteLine($"Email: {nuevoUsuario.Email}");
                    Console.WriteLine($"Telefono: {nuevoUsuario.Telefono}");
                    Console.WriteLine($"Fecha Registro: {nuevoUsuario.FechaRegistro:dd/MM/yyyy HH:mm:ss}");
                    Console.WriteLine($"Estado: {(nuevoUsuario.Activo ? "ACTIVO" : "INACTIVO")}");
                    
                    Console.WriteLine();
                    Console.Write("Desea registrar otro usuario? (S/N): ");
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
