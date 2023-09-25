using Isatays.CleanMinimalApi.Api.Models;
using Isatays.CleanMinimalApi.Core.Entities;
using Isatays.CleanMinimalApi.Core.Foods;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Isatays.CleanMinimalApi.Api.Controllers;

/// <summary>
/// Cotroller special for foods
/// </summary>
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/food")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class FoodController : BaseController
{
    [HttpGet("get")]
    [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(Food))]
    public async Task<IActionResult> GetFood(int userId)
    {
        var result = await Sender.Send(new GetFoodQuery(userId));

        if (result.IsFailed)
            return ProblemResponse(result.Error);

        return Ok(result.Value);
    }

    [HttpPost("create")]
    [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(int))]
    public async Task<IActionResult> CreateFood([FromBody] CreateFoodRequest request)
    {
        var result = await Sender.Send(new CreateFoodCommand(request.Name, request.Description));

        if (result.IsFailed)
            return ProblemResponse(result.Error);

        return Ok(result.Value);
    }

    [HttpPut("update")]
    [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(Unit))]
    public async Task<IActionResult> UpdateFood([FromBody] UpdateFoodRequest request)
    {
        var result = await Sender.Send(new UpdateFoodCommand(request.UserId, request.Name, request.Description));

        if (result.IsFailed)
            return ProblemResponse(result.Error);

        return Ok();
    }

    [HttpPut("delete")]
    [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(Unit))]
    public async Task<IActionResult> DeleteFood([FromBody] DeleteFoodRequest request)
    {
        var result = await Sender.Send(new DeleteFoodCommand(request.UserId));

        if (result.IsFailed)
            return ProblemResponse(result.Error);

        return Ok();
    }
}
