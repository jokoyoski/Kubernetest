using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kubernetestest.Controllers
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
        private readonly string name;
        private readonly string age;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IOptions<Joko>joko)
        {
            _logger = logger;
            name = joko.Value.name;
            age = joko.Value.age;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (name == null) {
                return Ok("oke");
            }
         _logger.LogInformation("probe...");
            return Ok(name);
        }
    }
}
