namespace Loquens.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController, Route("[controller]")]
public partial class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private const int RANGE = 10;

    private static readonly string[] Summaries =
    [
        "Balmy",
        "Bracing",
        "Chilly",
        "Cool",
        "Freezing",
        "Hot",
        "Mild",
        "Scorching",
        "Sweltering",
        "Warm",
    ];

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        this.LogMessage(RANGE);

        return Enumerable.Range(1, RANGE).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [LoggerMessage(LogLevel.Information, Message = "Ping {range}")]
    partial void LogMessage(int range);
}
