using KDS.Primitives.FluentResult;
using MediatR;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class CreateFoodCommand : IRequest<Result<int>>
{
    public int UserId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
