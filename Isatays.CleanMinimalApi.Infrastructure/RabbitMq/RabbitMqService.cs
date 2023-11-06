using Isatays.CleanMinimalApi.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Isatays.CleanMinimalApi.Infrastructure.RabbitMq;

public class RabbitMqService : IRabbitMqService
{
    private readonly IConfiguration _configuration;

    public RabbitMqService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendMessage(object obj)
    {
        var message = JsonSerializer.Serialize(obj);
        SendMessage(message);
    }

    public void SendMessage(string message)
    {
        var rabbitMqUri = _configuration["RabbitMqConf:rabbitMqConString"];
        var sectionOfConfiguration = _configuration.GetSection("RabbitMqConf");

        var factory = new ConnectionFactory() { Uri = new Uri(rabbitMqUri) };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: _configuration["RabbitMqConf:QueueName"],
                           durable: false,
                           exclusive: false,
                           autoDelete: false,
                           arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                           routingKey: _configuration["RabbitMqConf:QueueName"],
                           basicProperties: null,
                           body: body);
        }
    }
}