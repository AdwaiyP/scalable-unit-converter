namespace UnitConversionApi;

// This defines the JSON data the user must send us
public record ConversionRequest(double Value, string FromUnit, string ToUnit, string Category);