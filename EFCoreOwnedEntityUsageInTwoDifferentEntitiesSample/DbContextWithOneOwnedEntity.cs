using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFCoreOwnedEntityUsageInTwoDifferentEntitiesSample
{
    public class DbContextWithOneOwnedEntity : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=DbContextWithOneOwnedEntity;Trusted Connection=True");

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public Name DateRange { get; set; }
        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
