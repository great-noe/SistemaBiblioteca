using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Entidades
{
    [Table("reservas")]
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReserva { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        
        [ForeignKey("IdUsuario")]
        [Required]
        public virtual Usuario? Usuario { get; set; }

        [Required]
        public int IdLibro { get; set; }
        
        [ForeignKey("IdLibro")]
        [Required]
        public virtual Libro? Libro { get; set; }

        public DateTime FechaReserva { get; set; } = DateTime.Now;

        public DateTime FechaExpiracion 
        { 
            get => FechaReserva.AddDays(5); // 5 días por defecto
            set { } // Para EF Core
        }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Estado { get; set; } = "Pendiente"; 
        // Opciones: Pendiente, Confirmada, Cumplida, Cancelada, Expirada

        public int? IdPrestamo { get; set; }
        
        [ForeignKey("IdPrestamo")]
        public virtual Prestamo? Prestamo { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string? Prioridad { get; set; } // "Alta", "Media", "Baja"

        public int? PosicionCola { get; set; } // Posición en la cola de reservas

        public DateTime? FechaNotificacion { get; set; }

        public bool Notificado { get; set; } = false;

        [MaxLength(500)]
        public string? Observaciones { get; set; }

        public DateTime? FechaCancelacion { get; set; }

        [MaxLength(100)]
        public string? MotivoCancelacion { get; set; }
    }
}