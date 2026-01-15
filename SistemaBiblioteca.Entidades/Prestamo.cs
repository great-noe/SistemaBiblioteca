using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Entidades
{
    [Table("prestamos")]
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }

        public int IdLibro { get; set; }
        [ForeignKey("IdLibro")]
        public virtual Libro? Libro { get; set; }

        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
        public DateTime FechaDevolucionEstimada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }

        [Required]
        [MaxLength(20)]
        public string EstadoPrestamo { get; set; } = "Activo"; // Activo, Devuelto, Vencido

        public int DiasRetraso { get; set; } = 0;
        public decimal MontoMulta { get; set; } = 0;
        public bool MultaPagada { get; set; } = false;

        [MaxLength(500)]
        public string? Observaciones { get; set; }
    }
}