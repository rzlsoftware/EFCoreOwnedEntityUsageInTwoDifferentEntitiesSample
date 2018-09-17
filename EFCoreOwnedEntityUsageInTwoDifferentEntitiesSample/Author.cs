using System.Collections.Generic;

namespace EFCoreOwnedEntityUsageInTwoDifferentEntitiesSample
{
    public class Author
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
