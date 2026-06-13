using Microsoft.AspNetCore.Mvc;

namespace UnitConversionApi;

[ApiController]
[Route("api/[controller]")]
public class ConversionController : ControllerBase
{
    private readonly IEnumerable<IConversionStrategy> _strategies;

    // .NET will automatically give us our list of converters here
    public ConversionController(IEnumerable<IConversionStrategy> strategies)
    {
        _strategies = strategies;
    }

    [HttpPost("convert")]
    public IActionResult Convert([FromBody] ConversionRequest request)
    {
        // Find the converter that matches the requested category (e.g., "Length")
        var strategy = _strategies.FirstOrDefault(s => s.Category.Equals(request.Category, StringComparison.OrdinalIgnoreCase));
        
        if (strategy == null) 
            return BadRequest($"Category '{request.Category}' is not supported.");

        try
        {
            var result = strategy.Convert(request.Value, request.FromUnit, request.ToUnit);
            return Ok(new { result = Math.Round(result, 4) });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}