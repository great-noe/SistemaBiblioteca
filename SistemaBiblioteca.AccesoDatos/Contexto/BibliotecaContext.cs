using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Entidades;

namespace SistemaBiblioteca.AccesoDatos.Contexto
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Multa> Multas { get; set; }
        public DbSet<LibroAutor> LibrosAutores { get; set; }
        public DbSet<HistorialPrestamo> HistorialPrestamos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LibroAutor>()
                .HasKey(la => new { la.IdLibro, la.IdAutor });

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Categoria)
                .WithMany()
                .HasForeignKey(l => l.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Libro)
                .WithMany(l => l.Prestamos)
                .HasForeignKey(p => p.IdLibro)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Libro)
                .WithMany(l => l.Reservas)
                .HasForeignKey(r => r.IdLibro)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Multa>()
                .HasOne(m => m.Usuario)
                .WithMany()
                .HasForeignKey(m => m.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LibroAutor>()
                .HasOne(la => la.Libro)
                .WithMany(l => l.LibroAutores)
                .HasForeignKey(la => la.IdLibro)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LibroAutor>()
                .HasOne(la => la.Autor)
                .WithMany()
                .HasForeignKey(la => la.IdAutor)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}