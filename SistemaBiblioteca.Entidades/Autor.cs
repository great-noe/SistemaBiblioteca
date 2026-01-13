using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Entidades
{
    /// <summary>
    /// Representa un autor basado en la tabla 'autores' de la BD.
    /// </summary>
    [Table("autores")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Nacionalidad { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public DateTime? FechaFallecimiento { get; set; }

        public string? Biografia { get; set; }

        // En tu SQL 'Activo' es tinyint(1), en C# se mapea a bool
        public bool Activo { get; set; } = true;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Propiedad calculada útil para mostrar en Grids
        [NotMapped]
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}