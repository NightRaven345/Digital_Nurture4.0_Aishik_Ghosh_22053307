using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string username;
        while (true)
        {
            Console.Write("Enter your username: ");
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                username = input.Trim();
                break;
            }
            Console.WriteLine("Username cannot be empty. Please try again.");
        }

        var producer = new Producer();
        var consumer = new Consumer(username);

        _ = Task.Run(() => consumer.StartListening("chat-topic"));

        Console.WriteLine($"\nWelcome, {username}! Type your message below. Type 'exit' to leave.\n");

        while (true)
        {
            Console.Write($"{username}: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                continue;

            string trimmedInput = input.Trim();
            if (trimmedInput.ToLower() == "exit")
            {
                Console.WriteLine("Exiting chat...");
                break;
            }

            string formattedMessage = $"{username}: {trimmedInput}";
            await producer.SendMessage("chat-topic", formattedMessage);
        }
    }
}
