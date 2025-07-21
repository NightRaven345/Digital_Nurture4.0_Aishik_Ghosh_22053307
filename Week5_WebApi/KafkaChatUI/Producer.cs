using Confluent.Kafka;
using System.Threading.Tasks;

public class Producer
{
    public async Task SendMessage(string topic, string message)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        using var producer = new ProducerBuilder<Null, string>(config).Build();
        await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
    }
}
