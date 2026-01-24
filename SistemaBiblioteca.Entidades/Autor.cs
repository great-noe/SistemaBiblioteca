using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Entidades
{
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

        public bool Activo { get; set; } = true;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [NotMapped]
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}