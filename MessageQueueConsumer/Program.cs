using MessageQueueConsumer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureRabbitMq();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
