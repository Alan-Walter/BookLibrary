using BookLibrary.Db.Models;

using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Db
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}