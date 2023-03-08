using Microsoft.AspNetCore.Mvc;

namespace ExceptionControlFlowBenchmark.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("correct")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(5));

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("exception")]
        public async Task<IActionResult> GetException()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(5));

            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}