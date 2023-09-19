using Isatays.CleanMinimalApi.Core.Entities;
using Isatays.CleanMinimalApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Isatays.CleanMinimalApi.Infrastructure.Persistense;

public class FoodsContext : DbContext, IFoodsDbContext
{
    public DbSet<Food> Foods { get; set; }

    public FoodsContext(DbContextOptions<FoodsContext> options)
            : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
    }
}
