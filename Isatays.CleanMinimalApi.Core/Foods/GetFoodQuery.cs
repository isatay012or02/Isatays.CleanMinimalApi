using Isatays.CleanMinimalApi.Core.Entities;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class GetFoodQuery : IRequest<Result<Food>>
{
    public GetFoodQuery(int id, int userId)
    {
        Id = id;
        UserId = userId;
    }

    public int Id { get; set; } 

    public int UserId { get; set; }
}
