using System;

namespace SingletonPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Singleton Pattern...");

            Logger logger1 = Logger.GetInstance();
            logger1.Log("First log message");

            Logger logger2 = Logger.GetInstance();
            logger2.Log("Second log message");

            if (object.ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("Both logger instances are the same (Singleton confirmed).");
            }
            else
            {
                Console.WriteLine("Different logger instances found (Singleton failed).");
            }

            Console.ReadLine();
        }
    }
}
