using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            double presentValue = 10000;
            double rate = 0.05;
            int years = 5;

            Console.WriteLine("Financial Forecasting using Recursion:");
            double futureValue = FinancialForecaster.ForecastRecursive(presentValue, rate, years);
            Console.WriteLine($"Future Value: {futureValue:F2}");

        }
    }
}
