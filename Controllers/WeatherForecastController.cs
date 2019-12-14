using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TryUpdateModelAsyncProblem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new []
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            var value = new WeatherForecast()
            {
                Date = DateTime.Parse("2019-12-14"),
                TemperatureC = 100,
                Summary = ""
            };

            // curl --location --request POST 'https://localhost:5001/WeatherForecast' --header 'Content-Type: application/json' --data-raw '{"Date": "2019-12-01", "TemperatureC": 1, "Summary": "N/A"}' -k
            if (await TryUpdateModelAsync(value, ""))
            {
                return CreatedAtAction("Get", value);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
