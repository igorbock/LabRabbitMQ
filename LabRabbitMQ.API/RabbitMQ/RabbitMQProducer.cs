namespace LabRabbitMQ.RabbitMQ;

public class RabbitMQProducer : IRabbitMQProducer
{
    public async Task SendProductMessageAsync<T>(T message)
    {
        //Definição do servidor Rabbit MQ : usamos uma imagem Docker
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
        //Cria uma conexão RabbitMQ usando uma factory
        var connection = await factory.CreateConnectionAsync();
        //Cria um channel com sessão e model
        using  var channel = await connection.CreateChannelAsync();
        //declara a fila(queue) a seguir o nome e propriedades
        await channel.QueueDeclareAsync("product", exclusive: false);
        //Serializa a mensagem
        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);
        //Põe os dados na fila : product
        await channel.BasicPublishAsync(exchange: "", routingKey: "product", body: body);
    }
}
