using Isatays.CleanMinimalApi.Core.Entities;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class GetFoodQuery : IRequest<Result<Food>>
{
    public GetFoodQuery(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; set; }
}
