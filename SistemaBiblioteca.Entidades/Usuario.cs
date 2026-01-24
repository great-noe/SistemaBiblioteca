using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Entidades
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(20)]
        public string NumeroIdentificacion { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }

        [MaxLength(200)]
        public string? Direccion { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoUsuario { get; set; } = "Socio";

        public decimal MultasPendientes { get; set; } = 0;
        
        public bool Suspendido { get; set; } = false;
        public DateTime? FechaFinSuspension { get; set; }

        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        
        [NotMapped]
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}