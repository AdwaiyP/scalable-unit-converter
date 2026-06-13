namespace UnitConversionApi;

public class TemperatureConversionStrategy : IConversionStrategy
{
    public string Category => "Temperature";

    public double Convert(double value, string fromUnit, string toUnit)
    {
        string from = fromUnit.ToLower();
        string to = toUnit.ToLower();

        if (from == to) return value;

        // Step 1: Convert everything to Celsius first
        double celsius = from switch
        {
            "c" or "celsius" => value,
            "f" or "fahrenheit" => (value - 32) * 5 / 9,
            _ => throw new ArgumentException("Unsupported temperature unit.")
        };

        // Step 2: Convert Celsius to target unit
        return to switch
        {
            "c" or "celsius" => celsius,
            "f" or "fahrenheit" => (celsius * 9 / 5) + 32,
            _ => throw new ArgumentException("Unsupported temperature unit.")
        };
    }
}