using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Entidades
{
    [Table("historialprestamos")]
    public class HistorialPrestamo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistorial { get; set; }

        [Required]
        public int IdPrestamo { get; set; }
        
        [ForeignKey("IdPrestamo")]
        public virtual Prestamo? Prestamo { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Accion { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? DescripcionAccion { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(100)]
        public string UsuarioResponsable { get; set; } = "Sistema";

        public int? IdUsuario { get; set; }
        
        public int? IdLibro { get; set; }
        
        [MaxLength(50)]
        public string? EstadoAnterior { get; set; }
        
        [MaxLength(50)]
        public string? EstadoNuevo { get; set; }

        public DateTime? FechaPrestamoAnterior { get; set; }
        
        public DateTime? FechaDevolucionEstimadaAnterior { get; set; }
        
        public DateTime? FechaDevolucionRealAnterior { get; set; }

        public int? DiasPrestamo { get; set; }
        
        public int? DiasRenovacion { get; set; }
        
        public int? VecesRenovado { get; set; }

        [MaxLength(50)]
        public string? IpRegistro { get; set; }
        
        [MaxLength(100)]
        public string? Navegador { get; set; }
        
        [MaxLength(100)]
        public string? SistemaOperativo { get; set; }

        public int? IdMulta { get; set; }
        
        [ForeignKey("IdMulta")]
        public virtual Multa? Multa { get; set; }

        [MaxLength(500)]
        public string? Observaciones { get; set; }

        [MaxLength(50)]
        public string? TipoCambio { get; set; }

        public bool EsAutomatico { get; set; } = false;

        [MaxLength(200)]
        public string? CampoModificado { get; set; }
        
        [MaxLength(500)]
        public string? ValorAnterior { get; set; }
        
        [MaxLength(500)]
        public string? ValorNuevo { get; set; }
    }
}