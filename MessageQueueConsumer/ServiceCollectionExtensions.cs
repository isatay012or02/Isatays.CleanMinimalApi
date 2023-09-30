namespace MessageQueueConsumer;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureRabbitMq(this IServiceCollection services)
    {
        services.AddHostedService<RabbitMqListener>();

        return services;
    }
}
