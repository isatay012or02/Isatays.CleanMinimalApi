using KDS.Primitives.FluentResult;
using MediatR;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class DeleteFoodCommand : IRequest<Result>
{
    public DeleteFoodCommand(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; set; }
}
