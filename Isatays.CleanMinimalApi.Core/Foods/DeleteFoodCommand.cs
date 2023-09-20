using KDS.Primitives.FluentResult;
using MediatR;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class DeleteFoodCommand : IRequest<Result>
{
    public DeleteFoodCommand(int id, int userId)
    {
        Id = id;
        UserId = userId;
    }

    public int Id { get; set; }

    public int UserId { get; set; }
}
