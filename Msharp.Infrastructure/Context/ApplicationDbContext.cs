using Microsoft.EntityFrameworkCore;
using Msharp.Domain.Entities;

namespace Msharp.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Factory> Factories { get; set; }

    public DbSet<Employee> Employees { get; set; }

}
