using Confluent.Kafka;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Consumer
{
    private readonly string _username;
    private readonly TextBox _txtChat;
    private readonly TextBox _txtInput;

    public Consumer(string username, TextBox txtChat, TextBox txtInput)
    {
        _username = username;
        _txtChat = txtChat;
        _txtInput = txtInput;
    }

    public void StartListening(string topic)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = $"chat-ui-{_username}-{Guid.NewGuid()}",
            AutoOffsetReset = AutoOffsetReset.Latest
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
                    string message = cr.Message.Value;
                    _txtChat.Invoke((MethodInvoker)(() =>
                    {
                        _txtChat.AppendText($"{message}{Environment.NewLine}");
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error consuming message: {ex.Message}");
            }
        }
    }
}
