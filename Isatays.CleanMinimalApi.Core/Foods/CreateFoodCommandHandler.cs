using Isatays.CleanMinimalApi.Core.Entities;
using Isatays.CleanMinimalApi.Core.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Result<int>>
{
    private readonly IFoodsDbContext _foodsDbContext;

    public CreateFoodCommandHandler(IFoodsDbContext foodsDbContext)
    {
        _foodsDbContext = foodsDbContext;
    }

    public async Task<Result<int>> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var food = new Food()
            {
                Name = request.Name,
                Description = request.Description,
                CreationDate = DateTime.UtcNow,
                EditDate = null
            };

            await _foodsDbContext.Foods.AddAsync(food);
            await _foodsDbContext.SaveChangesAsync();

            return Result.Success(food.Id);
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}
