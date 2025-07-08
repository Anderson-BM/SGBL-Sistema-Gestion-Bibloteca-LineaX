using Microsoft.EntityFrameworkCore;
using SGBL.Core.Domain.Common;
using SGBL.Core.Domain.Entities;


namespace SGBL.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }



        public DbSet<Libro> Libro { get; set; } 
        public DbSet<Author> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; } 



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //FLUENT API

            #region tables

            // Configuración tablas
            modelBuilder.Entity<Libro>()
                .ToTable("Libros");

            modelBuilder.Entity<Author>()
                .ToTable("Autores");

            modelBuilder.Entity<Genero>()
                .ToTable("Generos");

            modelBuilder.Entity<Prestamo>()
                .ToTable("Prestamos"); 

            #endregion

            #region "primary keys"
            modelBuilder.Entity<Libro>()
               .HasKey(l => l.Id);

            modelBuilder.Entity<Author>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Genero>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Prestamo>()
                .HasKey(p => p.Id); 

            #endregion

            #region "Relationships"

            // Relaciones
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Author)
                .WithMany(a => a.Libro)
                .HasForeignKey(l => l.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); // cuando borro Author borro sus Libros

            modelBuilder.Entity<Genero>()
                .HasMany(g => g.Libro)
                .WithOne(l => l.Genero)
                .HasForeignKey(l => l.GeneroId)
                .OnDelete(DeleteBehavior.Cascade); // cuando borro el género borro los Libros

            //  Relación Prestamo -> Libro
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Libro)
                .WithMany()
                .HasForeignKey(p => p.LibroId)
                .OnDelete(DeleteBehavior.Restrict);

            //  Relación Prestamo -> Usuario
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId)
                .IsRequired(false); // ← esto indica que es opcional
            #endregion

            #region "Property configurations"

            #region Libro

            // Propiedades requeridas
            modelBuilder.Entity<Libro>()
                .Property(l => l.Name)
                .IsRequired();
            #endregion

            #region Author

            modelBuilder.Entity<Author>()
              .Property(a => a.Name)
              .IsRequired();
            #endregion

            #region Genero
            modelBuilder.Entity<Genero>().
              Property(g => g.Name)
              .IsRequired()
              .HasMaxLength(100);
            #endregion

            #region Prestamo
            modelBuilder.Entity<Prestamo>()
                .Property(p => p.Estado)
                .IsRequired();

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.FechaSolicitud)
                .IsRequired();
            #endregion



            #endregion
        }
    }
}
