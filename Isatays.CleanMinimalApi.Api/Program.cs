using Serilog;
using Isatays.CleanMinimalApi.Api.Features.Middlewares;
using Isatays.CleanMinimalApi.Api.Features.Swagger;
using Isatays.CleanMinimalApi.Api.Features.Versioning;
using Isatays.CleanMinimalApi.Api.Features.WebHost;
using Isatays.CleanMinimalApi.Api.Common.Options;
using Isatays.CleanMinimalApi.Infrastructure;
using Isatays.CleanMinimalApi.Core;
using Carter;

var builder = WebApplication.CreateBuilder(args);

var webHostOptions = new WebHostOptions(
    instanceName: builder.Configuration.GetValue<string>($"{WebHostOptions.SectionName}:InstanceName"),
    webAddress: builder.Configuration.GetValue<string>($"{WebHostOptions.SectionName}:WebAddress"));

try
{
    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(Log.Logger);

    Log.Information("{Msg} ({ApplicationName})...",
        "Запуск конфигурации проекта",
        webHostOptions.InstanceName);

    builder.ConfigureWebHost();

    builder.Services.ConfigureApplicationAssemblies();

    builder.Services.AddCarter();

    builder.Services
        .ConfigureInfrastructurePersistence(builder.Configuration, builder.Environment.EnvironmentName)
        .ConfigureInfrastructureServices(builder.Configuration, builder.Environment.EnvironmentName);

    var app = builder.Build();

    Log.Information("{Msg} ({ApplicationName})...",
        "Запуск сборки проекта",
        webHostOptions.InstanceName);

    app.UseConfiguredSwagger();
    app.UseConfiguredVersioning();
    app.UseHttpsRedirection();
    app.UseMiddleware<LoggingMiddleware>();
    app.UseMiddleware<ExceptionHandleMiddleware>();
    app.MapHealthChecks("/healthcheck");

    app.MapControllers();
    //app.MapFoodEndpoints();
    app.MapCarter();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Программа была выброшена с исплючением ({ApplicationName})!",
        webHostOptions.InstanceName);
}
finally
{
    Log.Information("{Msg}!", "Высвобождение ресурсов логгирования");
    await Log.CloseAndFlushAsync();
}
