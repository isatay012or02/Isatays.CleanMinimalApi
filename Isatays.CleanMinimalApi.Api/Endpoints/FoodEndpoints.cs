using Carter;
using Isatays.CleanMinimalApi.Api.Models;
using Isatays.CleanMinimalApi.Core.Entities;
using Isatays.CleanMinimalApi.Core.Foods;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Isatays.CleanMinimalApi.Api.Endpoints;

public class FoodEndpoints : ICarterModule
{
    void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/food", GetFood).WithName(nameof(GetFood)).WithGroupName("Foods");

        app.MapPost("api/food", CreateFood).WithName(nameof(CreateFood)).WithGroupName("Foods");

        app.MapPut("api/food", UpdateFood).WithName(nameof(UpdateFood)).WithGroupName("Foods");

        app.MapDelete("api/food", DeleteFood).WithName(nameof(DeleteFood)).WithGroupName("Foods");
    }

    [HttpGet("get", Name = nameof(GetFood))]
    [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(Food))]
    public static async Task<IResult> GetFood(int userId, ISender sender)
    {
        var result = await sender.Send(new GetFoodQuery(userId));

        //if (result.IsFailed)

        return Results.Ok(result.Value);
    }

    [HttpPost("create", Name = nameof(CreateFood))]
    [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(int))]
    public static async Task<IResult> CreateFood([FromBody] CreateFoodRequest request, ISender sender)
    {
        var result = await sender.Send(new CreateFoodCommand(request.Name, request.Description));

        //if (result.IsFailed)

        return Results.Ok(result.Value);
    }

    [HttpPut("update", Name = nameof(UpdateFood))]
    [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(Unit))]
    public static async Task<IResult> UpdateFood([FromBody] UpdateFoodRequest request, ISender sender)
    {
        var result = await sender.Send(new UpdateFoodCommand(request.UserId, request.Name, request.Description));

        //if (result.IsFailed)

        return Results.Ok();
    }

    [HttpDelete("delete", Name = nameof(DeleteFood))]
    [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(Unit))]
    public static async Task<IResult> DeleteFood([FromBody] DeleteFoodRequest request, ISender sender)
    {
        var result = await sender.Send(new DeleteFoodCommand(request.UserId));

        //if (result.IsFailed)

        return Results.Ok();
    }
}
