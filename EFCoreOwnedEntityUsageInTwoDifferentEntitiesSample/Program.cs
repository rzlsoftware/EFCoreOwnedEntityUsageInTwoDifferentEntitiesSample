using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace EFCoreOwnedEntityUsageInTwoDifferentEntitiesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextWithOneOwnedEntitySample();
            ReadLine();
        }

        private static void DbContextWithOneOwnedEntitySample()
        {
            using (var context = new DbContextWithOneOwnedEntity())
            {
                var entityType = context.Model.FindEntityType(typeof(Name));

                WriteLine(
                    entityType is null
                    ? $"The entityType for Type:{typeof(Name)} was not found."
                    : $"The entityType {entityType.Name} was found."
                    );
            }
        }
    }
}
