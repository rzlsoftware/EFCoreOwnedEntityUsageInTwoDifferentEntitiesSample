# EFCoreOwnedEntityUsageInTwoDifferentEntitiesSample

Sample Project for [EFCore Issue 13338](https://github.com/aspnet/EntityFrameworkCore/issues/13338).

When using an Owned Entity in different EntityTypes EF Core doesn´t find the Owned Entitytype in the `DbContext.Model`.

### Steps to reproduce
```csharp
public class Name
{
    public string First { get; set; }
    public string Last { get; set; }
}
public class Author
{
    public int Id { get; set; }
    public Name Name { get; set; }
    public string Description { get; set; }
}
public class Customer
{
    public int Id { get; set; }
    public Name Name { get; set; }
    public int CustomerNumber { get; set; }
}
```

```csharp
public class DbContextWithOneOwnedEntity : DbContext
{
    public DbSet<Author> Authors { get; set; }
    ...
}
public class DbContextWithTwoOrMoreOwnedEntities : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    ...
}
```

```csharp
var entityType = new DbContextWithOneOwnedEntity().Model.FindEntityType(typeof(Name)); // works
var entityType = new DbContextWithTwoOrMoreOwnedEntities().Model.FindEntityType(typeof(Name)); // entityType is null
```

# Resolved with:
 **Answer from** @ajcvickers
> This is because once a CLR type is mapped to multiple different types in the model, then the model type can no longer be identified just by the CLR type. Therefore, each model type becomes a "weak entity type" which is defined by both it's CLR type and the defining navigation property from it's owner. These can be found using a different overload of `FindEntityType`:
> 
> ```cs
> var customerType = context.Model.FindEntityType(typeof(Customer));
> var customerNameType = context.Model.FindEntityType(typeof(Name), nameof(Customer.Name), customerType);
> 
> var authorType = context.Model.FindEntityType(typeof(Author));
> var authorNameType = context.Model.FindEntityType(typeof(Name), nameof(Author.Name), authorType);
> ```
