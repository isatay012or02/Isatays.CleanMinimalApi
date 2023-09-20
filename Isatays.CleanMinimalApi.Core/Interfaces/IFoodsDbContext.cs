using Isatays.CleanMinimalApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Isatays.CleanMinimalApi.Core.Interfaces;

public interface IFoodsDbContext
{
    DbSet<Food> Foods { get; set; }

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
