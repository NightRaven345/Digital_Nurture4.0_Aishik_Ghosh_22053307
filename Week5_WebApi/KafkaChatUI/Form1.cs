using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafkaChatUI
{
    public partial class Form1 : Form
    {
        private string _username = null!;
        private Producer _producer = null!;
        private Consumer _consumer = null!;

        public Form1()
        {
            InitializeComponent();  // Use the one from Designer
            InitializeChat();
        }

        private void InitializeChat()
        {
            _username = PromptUsername();
            _producer = new Producer();

            _consumer = new Consumer(_username, txtChat, txtInput);
            _ = Task.Run(() => _consumer.StartListening("chat-topic"));

            txtChat.AppendText($"Welcome, {_username}! Type 'exit' to leave.{Environment.NewLine}");
            txtInput.KeyDown += TxtInput_KeyDown!;
            btnSend.Click += BtnSend_Click!;
        }

        private string PromptUsername()
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter your username:", "Chat Login", "User");
            return string.IsNullOrWhiteSpace(name) ? "User" : name.Trim();
        }

        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            await SendMessageAsync();
        }

        private async void TxtInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await SendMessageAsync();
            }
        }

        private async Task SendMessageAsync()
        {
            string message = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            if (message.ToLower() == "exit")
            {
                Application.Exit();
                return;
            }

            string formattedMessage = $"{_username}: {message}";
            await _producer.SendMessage("chat-topic", formattedMessage);

            txtChat.AppendText($"{formattedMessage}{Environment.NewLine}");
            txtInput.Clear();
        }
    }
}
