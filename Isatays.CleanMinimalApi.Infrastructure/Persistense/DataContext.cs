using Isatays.CleanMinimalApi.Core.Entities;
using Isatays.CleanMinimalApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Isatays.CleanMinimalApi.Infrastructure.Persistense;

public class DataContext : DbContext, IFoodsDbContext
{
    public DbSet<Food> Foods { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
    }
}
