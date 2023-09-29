using Isatays.CleanMinimalApi.Core.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Isatays.CleanMinimalApi.Infrastructure.RabbitMq;

public class RabbitMqService : IRabbitMqService
{
    public void SendMessage(object obj)
    {
        var message = JsonSerializer.Serialize(obj);
        SendMessage(message);
    }

    public void SendMessage(string message)
    {
        // Не забудьте вынести значения "localhost" и "MyQueue"
        // в файл конфигурации
        var factory = new ConnectionFactory() { Uri = new Uri("amqps://ocwiksvx:wcGxIMwWx6oU4m50hfmdns2JASmpQXsj@mustang.rmq.cloudamqp.com/ocwiksvx") };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "MyQueue",
                           durable: false,
                           exclusive: false,
                           autoDelete: false,
                           arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                           routingKey: "MyQueue",
                           basicProperties: null,
                           body: body);
        }
    }
}