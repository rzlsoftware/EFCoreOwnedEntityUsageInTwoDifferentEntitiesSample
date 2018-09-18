using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace EFCoreOwnedEntityUsageInTwoDifferentEntitiesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("One Owned Entity:");
            DbContextWithOneOwnedEntitySample();

            WriteLine("\n\nTwo ore more Owned Entities:");
            DbContextWithTwoOrMoreOwnedEntitiesSample();

            WriteLine("\n\n\nPositive Examples, should both work:");

            WriteLine("\n\nOne Owned Entity:");
            DbContextWithOneOwnedEntityPositiveSample();

            WriteLine("\n\nTwo ore more Owned Entities:");
            DbContextWithTwoOrMoreOwnedEntitiesPositiveSample();

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
                    : $"The entityType {entityType.Name} was found."            // -> will be found
                    );
            }
        }

        private static void DbContextWithTwoOrMoreOwnedEntitiesSample()
        {
            using (var context = new DbContextWithTwoOrMoreOwnedEntities())
            {
                var entityType = context.Model.FindEntityType(typeof(Name));

                WriteLine(
                    entityType is null
                    ? $"The entityType for Type:{typeof(Name)} was not found."  // -> won´t find anything
                    : $"The entityType {entityType.Name} was found."
                    );
            }
        }

        private static void DbContextWithOneOwnedEntityPositiveSample()
        {
            using (var context = new DbContextWithOneOwnedEntity())
            {
                var authorEntityType = context.Model.FindEntityType(typeof(Author));
                var authorNameEntityType = context.Model.FindEntityType(typeof(Name), nameof(Author.Name), authorEntityType);

                WriteLine(
                    authorNameEntityType is null
                    ? $"The authorNameEntityType for Type:{typeof(Name)} was not found."
                    : $"The authorNameEntityType {authorNameEntityType.Name} was found."
                    );
            }
        }

        private static void DbContextWithTwoOrMoreOwnedEntitiesPositiveSample()
        {
            using (var context = new DbContextWithTwoOrMoreOwnedEntities())
            {
                var authorEntityType = context.Model.FindEntityType(typeof(Author));
                var authorNameEntityType = context.Model.FindEntityType(typeof(Name), nameof(Author.Name), authorEntityType);
                var customerEntityType = context.Model.FindEntityType(typeof(Customer));
                var customerNameEntityType = context.Model.FindEntityType(typeof(Name), nameof(Customer.Name), customerEntityType);

                WriteLine(
                    authorNameEntityType is null
                    ? $"The authorNameEntityType for Type:{typeof(Name)} was not found."
                    : $"The authorNameEntityType {authorNameEntityType.Name} was found."
                    );
                WriteLine(
                    customerNameEntityType is null
                    ? $"The customerNameEntityType for Type:{typeof(Name)} was not found."
                    : $"The customerNameEntityType {customerNameEntityType.Name} was found."
                    );
            }
        }
    }
}
