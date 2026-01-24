using SistemaBiblioteca.AccesoDatos.Contexto;
using SistemaBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace SistemaBiblioteca.AccesoDatos.Repositorios
{
    public class UsuarioRepository
    {
        private readonly BibliotecaContext _context;

        public UsuarioRepository(BibliotecaContext context) => _context = context;

        public List<Usuario> ObtenerTodos() 
        {
            return _context.Usuarios.Where(u => u.Activo).ToList();
        }

        public Usuario? ObtenerPorId(int id) => _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

        public Usuario? ObtenerPorIdentificacion(string numeroIdentificacion)
        {
            return _context.Usuarios.FirstOrDefault(u => u.NumeroIdentificacion == numeroIdentificacion);
        }

        public void Insertar(Usuario usuario)
        {
            // Validaciones completas antes de insertar
            ValidarUsuario(usuario);

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        private void ValidarUsuario(Usuario usuario)
        {
            // 1. Validar campos obligatorios no vacíos
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                throw new Exception("El apellido es obligatorio");

            if (string.IsNullOrWhiteSpace(usuario.NumeroIdentificacion))
                throw new Exception("El número de identificación es obligatorio");

            // 2. Validar longitudes mínimas
            if (usuario.Nombre.Trim().Length < 2)
                throw new Exception("El nombre debe tener al menos 2 caracteres");

            if (usuario.Apellido.Trim().Length < 2)
                throw new Exception("El apellido debe tener al menos 2 caracteres");

            if (usuario.NumeroIdentificacion.Trim().Length < 5)
                throw new Exception("El número de identificación debe tener al menos 5 caracteres");

            // 3. Validar que no contengan solo números o caracteres especiales
            if (!Regex.IsMatch(usuario.Nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                throw new Exception("El nombre solo debe contener letras");

            if (!Regex.IsMatch(usuario.Apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                throw new Exception("El apellido solo debe contener letras");

            // 4. Validar formato de email si se proporciona
            if (!string.IsNullOrWhiteSpace(usuario.Email))
            {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(usuario.Email, emailPattern))
                    throw new Exception("El formato del email no es válido");

                // Validar email único
                var emailExistente = _context.Usuarios
                    .FirstOrDefault(u => u.Email == usuario.Email && u.IdUsuario != usuario.IdUsuario);
                if (emailExistente != null)
                    throw new Exception("El email ya está registrado por otro usuario");
            }

            // 5. Validar teléfono si se proporciona
            if (!string.IsNullOrWhiteSpace(usuario.Telefono))
            {
                if (!Regex.IsMatch(usuario.Telefono, @"^[0-9\-\+\(\)\s]+$"))
                    throw new Exception("El teléfono solo debe contener números y caracteres válidos (-, +, (, ))");

                if (usuario.Telefono.Length < 7 || usuario.Telefono.Length > 20)
                    throw new Exception("El teléfono debe tener entre 7 y 20 caracteres");
            }

            // 6. Validar identificación única
            var identificacionExistente = ObtenerPorIdentificacion(usuario.NumeroIdentificacion);
            if (identificacionExistente != null && identificacionExistente.IdUsuario != usuario.IdUsuario)
                throw new Exception("El número de identificación ya está registrado");

            // 7. Validar edad mínima si se proporciona fecha de nacimiento
            if (usuario.FechaNacimiento.HasValue)
            {
                var edad = DateTime.Now.Year - usuario.FechaNacimiento.Value.Year;
                if (usuario.FechaNacimiento.Value > DateTime.Now.AddYears(-edad)) edad--;

                if (edad < 5)
                    throw new Exception("El usuario debe tener al menos 5 años de edad");

                if (edad > 120)
                    throw new Exception("La fecha de nacimiento no es válida");
            }
        }

        public void Actualizar(Usuario usuario)
        {
            var usuarioExistente = ObtenerPorId(usuario.IdUsuario);
            if (usuarioExistente == null)
                throw new Exception("Usuario no encontrado");

            if (!string.IsNullOrWhiteSpace(usuario.Email))
            {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(usuario.Email, emailPattern))
                    throw new Exception("El formato del email no es valido");

                var emailDuplicado = _context.Usuarios
                    .FirstOrDefault(u => u.Email == usuario.Email && u.IdUsuario != usuario.IdUsuario);
                if (emailDuplicado != null)
                    throw new Exception("El email ya esta registrado por otro usuario");
            }

            usuario.FechaRegistro = usuarioExistente.FechaRegistro;
            usuario.IdUsuario = usuarioExistente.IdUsuario;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var usuario = ObtenerPorId(id);
            if (usuario != null)
            {
                usuario.Activo = false;
                _context.SaveChanges();
            }
        }

        public Usuario? BuscarPorTermino(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return null;

            termino = termino.ToLower();

            return _context.Usuarios
                .FirstOrDefault(u => 
                    u.Nombre.ToLower().Contains(termino) ||
                    u.Apellido.ToLower().Contains(termino) ||
                    u.Email.ToLower().Contains(termino) ||
                    u.NumeroIdentificacion.ToLower().Contains(termino));
        }
    }
}
