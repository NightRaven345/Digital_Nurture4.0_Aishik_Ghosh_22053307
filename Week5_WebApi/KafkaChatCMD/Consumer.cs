using Confluent.Kafka;
using System;

public class Consumer
{
    private readonly string _username;

    public Consumer(string username)
    {
        _username = username;
    }

    public void StartListening(string topic)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = $"chat-session-{_username}-{Guid.NewGuid()}",
            AutoOffsetReset = AutoOffsetReset.Latest,
            EnableAutoCommit = true
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe(topic);

        while (true)
        {
            try
            {
                var cr = consumer.Consume();

                if (!cr.Message.Value.StartsWith($"{_username}:"))
                {
                    // Clear current line, print message, then new prompt on same line
                    Console.Write($"\r{new string(' ', Console.WindowWidth)}\r"); // Clear current line
                    Console.WriteLine($"{cr.Message.Value}");
                    Console.Write($"{_username}: ");
                }
            }
            catch (ConsumeException ex)
            {
                Console.WriteLine($"Kafka consume error: {ex.Error.Reason}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
