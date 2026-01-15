namespace SistemaBiblioteca.AccesoDatos
{
    public static class DatabaseConfig
    {
        // ✓ Cadena de conexión centralizada
        public static string ConnectionString => "server=localhost;database=BibliotecaDB;user=root;password=tu_password";

        // ✓ Método GetConnection() para obtener la versión del servidor (requerido por Pomelo)
        public static MySqlServerVersion GetServerVersion()
        {
            return new MySqlServerVersion(new Version(8, 0, 31));
        }

        // "Esta clase centraliza la configuración de conexión para evitar errores si el servidor cambia"
    }
}
