using System;

namespace FinancialForecasting
{
    public class FinancialForecaster
    {
        public static double ForecastRecursive(double presentValue, double rate, int years)
        {
            if (years == 0)
                return presentValue;

            return ForecastRecursive(presentValue, rate, years - 1) * (1 + rate);
        }

    }
}
