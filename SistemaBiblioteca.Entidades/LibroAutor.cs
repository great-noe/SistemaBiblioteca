using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBiblioteca.Entidades
{
    [Table("libros_autores")]
    public class LibroAutor
    {
        [Required]
        public int IdLibro { get; set; }
        
        [ForeignKey("IdLibro")]
        public virtual Libro? Libro { get; set; }

        [Required]
        public int IdAutor { get; set; }
        
        [ForeignKey("IdAutor")]
        public virtual Autor? Autor { get; set; }

        // Propiedades adicionales para la relación
        [MaxLength(50)]
        public string? Rol { get; set; } // "Autor", "Coautor", "Editor", etc.

        public int? OrdenFirma { get; set; } // Orden de firma en portada (1, 2, 3...)

        [MaxLength(500)]
        public string? Notas { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        
        public bool Activo { get; set; } = true;
    }
}