using Isatays.CleanMinimalApi.Api.Errors;
using Isatays.CleanMinimalApi.Api.Extensions;
using Isatays.CleanMinimalApi.Core.Entities;
using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using System.Net.Mime;
using Foods = Isatays.CleanMinimalApi.Core.Foods;

var builder = WebApplication.CreateBuilder();

var app = builder.ConfigureBuilder(builder.Configuration, builder.Environment.EnvironmentName).Build().ConfigureApp();

_ = app.MapGet("/foods", async (IMediator mediator, int id, int userId) => Results.Ok(await mediator.Send(Result.Success(new Foods.GetFoodQuery(id, userId)))))
    .WithGroupName("Foods")
    .Produces<Food>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json)
    .Produces<ApiError>(StatusCodes.Status400BadRequest, contentType: MediaTypeNames.Application.Json)
    .Produces<ApiError>(StatusCodes.Status404NotFound, contentType: MediaTypeNames.Application.Json)
    .Produces<ApiError>(StatusCodes.Status500InternalServerError, contentType: MediaTypeNames.Application.Json);

_ = app.MapPost("/foods", async (IMediator mediator, HttpRequest httpRequest, Foods.CreateFoodCommand command) => Results.Created(UriHelper.GetEncodedUrl(httpRequest), await mediator.Send(command)))
    .WithGroupName("Foods")
    .Produces<Food>(StatusCodes.Status201Created, contentType: MediaTypeNames.Application.Json)
    .Produces<ApiError>(StatusCodes.Status400BadRequest, contentType: MediaTypeNames.Application.Json)
    .Produces<ApiError>(StatusCodes.Status500InternalServerError, contentType: MediaTypeNames.Application.Json);

try
{
    Log.Information("Starting host");
    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
