using Microsoft.EntityFrameworkCore;

namespace EFCoreOwnedEntityUsageInTwoDifferentEntitiesSample
{
    public class DbContextWithOneOwnedEntity : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=DbContextWithOneOwnedEntity;Trusted Connection=True");

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
