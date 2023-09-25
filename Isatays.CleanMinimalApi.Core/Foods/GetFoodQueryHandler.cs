using Isatays.CleanMinimalApi.Core.Common.Exceptions;
using Isatays.CleanMinimalApi.Core.Entities;
using Isatays.CleanMinimalApi.Core.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, Result<Food>>
{
    private readonly IFoodsDbContext _foodsDbContext;

	public GetFoodQueryHandler(IFoodsDbContext foodsDbContext)
	{
		_foodsDbContext = foodsDbContext;
	}

	public async Task<Result<Food>> Handle(GetFoodQuery request, CancellationToken cancellationToken)
	{
		var food = await _foodsDbContext.Foods
			.Where(f => f.UserId.Equals(request.UserId))
			.FirstAsync();

		if (food is null)
		{
            throw new NotFoundException(nameof(Food), request.UserId);
        }

		return Result.Success(food);
	}
}
