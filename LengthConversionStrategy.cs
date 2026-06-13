namespace UnitConversionApi;

public class LengthConversionStrategy : IConversionStrategy
{
    public string Category => "Length";

    // A dictionary storing how many meters are in 1 unit
    private readonly Dictionary<string, double> _toMeterFactors = new(StringComparer.OrdinalIgnoreCase)
    {
        { "m", 1.0 },
        { "cm", 0.01 },
        { "mm", 0.001 },
        { "ft", 0.3048 },
        { "inch", 0.0254 }
    };

    public double Convert(double value, string fromUnit, string toUnit)
    {
        if (!_toMeterFactors.TryGetValue(fromUnit, out var fromFactor) ||
            !_toMeterFactors.TryGetValue(toUnit, out var toFactor))
        {
            throw new ArgumentException("Unsupported length unit provided.");
        }

        // Step 1: Convert input to Meters (e.g., 5 feet -> 1.524 meters)
        double valueInMeters = value * fromFactor;

        // Step 2: Convert Meters to target unit (e.g., 1.524 meters -> 152.4 cm)
        return valueInMeters / toFactor;
    }
}