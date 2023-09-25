using Isatays.CleanMinimalApi.Core.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, Result>
{
    private readonly IFoodsDbContext _foodsDbContext;

	public DeleteFoodCommandHandler(IFoodsDbContext foodsDbContext)
	{
		_foodsDbContext = foodsDbContext;
	}

	public async Task<Result> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
	{
		var result = await _foodsDbContext.Foods.
			Where(f => f.UserId.Equals(request.UserId))
			.FirstAsync();

		_foodsDbContext.Foods.Remove(result);
		await _foodsDbContext.SaveChangesAsync();

		return Result.Success();
	}
}
