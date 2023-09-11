using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace OptionsPattern.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult  Get()
        {
            var city = _configuration.GetValue<string>("WeatherOptions:City");
            var state = _configuration.GetValue<string>("WeatherOptions:State");
            var temperature = _configuration.GetValue<int>("WeatherOptions:Temperature");
            var summary = _configuration.GetValue<string>("WeatherOptions:Summary");
            return Ok(new
            {
                City = city,
                State = state,
                Temperature = temperature,
                Summary = summary
            });
        }
    }
}