using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Entidades
{
    [Table("libros")]
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public int IdCategoria { get; set; }
        
        [ForeignKey("IdCategoria")]
        public virtual Categoria? Categoria { get; set; }

        [MaxLength(100)]
        public string? Editorial { get; set; }

        public int? AnioPublicacion { get; set; }

        public int? NumeroPaginas { get; set; }

        [MaxLength(50)]
        public string? Idioma { get; set; } = "Espanol";

        public string? Descripcion { get; set; }

        [Required]
        public int CantidadTotal { get; set; } = 1;

        [Required]
        public int CantidadDisponible { get; set; } = 1;

        [MaxLength(50)]
        public string? Ubicacion { get; set; }

        public bool Activo { get; set; } = true;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Estado físico del libro (Excelente, Bueno, Regular, Malo, En Reparación)
        [MaxLength(20)]
        public string EstadoFisico { get; set; } = "Excelente";

        public virtual ICollection<LibroAutor>? LibroAutores { get; set; }
        public virtual ICollection<Prestamo>? Prestamos { get; set; }
        public virtual ICollection<Reserva>? Reservas { get; set; }

        [NotMapped]
        public bool TieneDisponibilidad => Activo && CantidadDisponible > 0;

        [NotMapped]
        public string InfoCompleta => $"{Titulo} - {ISBN} ({CantidadDisponible}/{CantidadTotal} disponibles)";
    }
}
