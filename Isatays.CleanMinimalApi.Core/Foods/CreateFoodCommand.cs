using KDS.Primitives.FluentResult;
using MediatR;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class CreateFoodCommand : IRequest<Result<int>>
{
    public CreateFoodCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; set; }

    public string Description { get; set; }
}
