using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace OptionsPattern.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherOptions _weatherOptions;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<WeatherOptions> weatherOptions)
        {
            _logger = logger;
            _weatherOptions = weatherOptions.Value;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult  Get()
        {
            return Ok(new
            {
                _weatherOptions.City,
                _weatherOptions.State,
                _weatherOptions.Temperature,
                _weatherOptions.Summary
            });
        }
    }
}