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
