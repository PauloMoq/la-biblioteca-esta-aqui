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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        LibraryContext libraryContext = new LibraryContext();
        optionsBuilder.UseSqlite(
            "Data Source=" +
             //  "C:\\Users\\moqp3\\Documents\\GitHub\\la-biblioteca-esta-aqui\\ressources\\library.db"
             "C:\\Users\\natha\\Desktop\\Bureau\\BUT\\BUT_3\\.Net\\Projet avec Paul\\la-biblioteca-esta-aqui\\ressources\\library.db"
            );
<<<<<<< Updated upstream
            "Data Source=C:\\Users\\moqp3\\Documents\\GitHub\\la-biblioteca-esta-aqui\\ressources\\library.db");
        string sql = File.ReadAllText("C:\\Users\\moqp3\\Documents\\GitHub\\la-biblioteca-esta-aqui\\ressources\\LibraryInit.sql");
        Database.ExecuteSqlRaw(sql);
=======
        // Database.ExecuteSqlRaw("C:\\Users\\natha\\Desktop\\Bureau\\BUT\\BUT_3\\.Net\\Projet avec Paul\\la-biblioteca-esta-aqui\\ressources\\LibraryInit.sql");
>>>>>>> Stashed changes
    }
}
