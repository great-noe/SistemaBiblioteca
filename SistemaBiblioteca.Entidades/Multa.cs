using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Entidades
{
    [Table("multas")]
    public class Multa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMulta { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        
        [ForeignKey("IdUsuario")]
        [Required]
        public virtual Usuario? Usuario { get; set; }

        public int? IdPrestamo { get; set; }
        
        [ForeignKey("IdPrestamo")]
        public virtual Prestamo? Prestamo { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 999999.99)]
        public decimal Monto { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "varchar(3)")]
        public string Moneda { get; set; } = "USD";

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Motivo { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Descripcion { get; set; }

        public DateTime FechaGeneracion { get; set; } = DateTime.Now;

        public DateTime FechaVencimiento 
        { 
            get => FechaGeneracion.AddDays(30);
            set { }
        }

        public DateTime? FechaPago { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Estado { get; set; } = "Pendiente";

        [Column(TypeName = "decimal(10,2)")]
        public decimal MontoPagado { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal SaldoPendiente 
        { 
            get => Monto - MontoPagado;
            set { }
        }

        public int? DiasRetraso { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? TipoSancion { get; set; }

        public bool BloqueoUsuario { get; set; } = false;

        public DateTime? FechaBloqueo { get; set; }

        public DateTime? FechaDesbloqueo { get; set; }

        [MaxLength(100)]
        public string? MetodoPago { get; set; }

        [MaxLength(50)]
        public string? ComprobantePago { get; set; }

        [MaxLength(500)]
        public string? Observaciones { get; set; }
    }
}