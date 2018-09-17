using Microsoft.EntityFrameworkCore;

namespace EFCoreOwnedEntityUsageInTwoDifferentEntitiesSample
{
    public class DbContextWithOneOwnedEntity : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=DbContextWithOneOwnedEntity;Trusted Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(b =>
            {
                b.ToTable("Authors");
                b.OwnsOne(a => a.Name);
            });
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
