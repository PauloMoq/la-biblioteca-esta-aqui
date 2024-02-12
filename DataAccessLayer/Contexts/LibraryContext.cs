using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

public class LibraryContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<Book> Books { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable(nameof(Book));
            entity.HasKey(b => b.Id);
            entity.HasOne(b => b.Author) // Un livre a un auteur
                  .WithMany() // Un auteur a plusieurs livres
                  .HasForeignKey("id_author"); // Utilisation de la bonne clé étrangère
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(a => a.Id);

            // Si vous avez d'autres configurations pour Author, elles iraient ici
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(l => l.Id);

            // Si vous avez d'autres configurations pour Library, elles iraient ici
        });
    }

}
