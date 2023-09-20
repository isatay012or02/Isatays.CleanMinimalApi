using KDS.Primitives.FluentResult;
using MediatR;

namespace Isatays.CleanMinimalApi.Core.Foods;

public class UpdateFoodCommand : IRequest<Result>
{
    public UpdateFoodCommand(int id, int userId, string name, string description)
    {
        Id = id;
        UserId= userId;
        Name = name;
        Description = description;
    }

    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
