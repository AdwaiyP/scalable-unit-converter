using UnitConversionApi;

var builder = WebApplication.CreateBuilder(args);

// 1. Tell .NET to support standard Web API Controllers
builder.Services.AddControllers();

// 2. Register your conversion plugins
builder.Services.AddSingleton<IConversionStrategy, LengthConversionStrategy>();
builder.Services.AddSingleton<IConversionStrategy, TemperatureConversionStrategy>();

var app = builder.Build();

// 3. Map your controllers so the web server can route traffic to them
app.MapControllers();

app.Run();