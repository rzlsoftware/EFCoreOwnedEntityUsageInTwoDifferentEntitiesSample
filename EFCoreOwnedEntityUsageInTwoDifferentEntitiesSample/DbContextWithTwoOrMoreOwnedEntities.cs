using Microsoft.EntityFrameworkCore;

namespace EFCoreOwnedEntityUsageInTwoDifferentEntitiesSample
{
    public class DbContextWithTwoOrMoreOwnedEntities : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=DbContextWithTwoOrMoreOwnedEntities;Trusted Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(b =>
            {
                b.ToTable("Authors");
                b.OwnsOne(a => a.Name);
            });

            modelBuilder.Entity<Customer>(b =>
            {
                b.ToTable("Customers");
                b.OwnsOne(a => a.Name);
            });
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
