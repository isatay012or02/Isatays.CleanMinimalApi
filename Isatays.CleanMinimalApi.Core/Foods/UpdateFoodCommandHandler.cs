using Isatays.CleanMinimalApi.Core.Common.Exceptions;
using Isatays.CleanMinimalApi.Core.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, Result>
{
    private readonly IFoodsDbContext _foodsDbContext;

    public UpdateFoodCommandHandler(IFoodsDbContext foodsDbContext)
    {
        _foodsDbContext = foodsDbContext;
    }

    public async Task<Result> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
    {
        var query = await _foodsDbContext.Foods.FirstOrDefaultAsync(f => f.UserId.Equals(request.UserId));

        if (query == null)
        {
            //Result.Failure();
            throw new NotFoundException(nameof(query), request.UserId);
        }

        query.Name = request.Name;
        query.Description = request.Description;
        query.EditDate = DateTime.UtcNow;
        await _foodsDbContext.SaveChangesAsync();

        return Result.Success();
    }
}
