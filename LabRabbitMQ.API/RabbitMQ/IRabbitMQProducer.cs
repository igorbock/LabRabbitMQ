namespace LabRabbitMQ.RabbitMQ;

public interface IRabbitMQProducer
{
    Task SendProductMessageAsync<T>(T message);
}
