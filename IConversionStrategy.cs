namespace UnitConversionApi;

// This is our blueprint interface
public interface IConversionStrategy
{
    string Category { get; }
    double Convert(double value, string fromUnit, string toUnit);
}