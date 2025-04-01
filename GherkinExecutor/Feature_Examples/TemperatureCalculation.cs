namespace gherkinexecutor.Feature_Examples
{
    public static class TemperatureCalculations
    {
        public static int ConvertFahrenheitToCelsius(int input)
        {
            return ((input - 32) * 5) / 9;
        }
    }
}
