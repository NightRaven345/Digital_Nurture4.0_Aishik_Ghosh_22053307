using KafkaChatUI;
using System;
using System.Windows.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize(); // For .NET 6+
        Application.Run(new Form1());
    }
}
