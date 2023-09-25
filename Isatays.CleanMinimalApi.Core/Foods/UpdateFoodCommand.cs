using KDS.Primitives.FluentResult;
using MediatR;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class UpdateFoodCommand : IRequest<Result>
{
    public UpdateFoodCommand(int userId, string name, string description)
    {
        UserId = userId;
        Name = name;
        Description = description;
    }

    public int UserId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
