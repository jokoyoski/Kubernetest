using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kubernetestest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ValuesController> _logger;
        private readonly string name;
        private readonly string age;

        public ValuesController(ILogger<ValuesController> logger, IOptions<Joko> joko)
        {
            _logger = logger;
            name = joko.Value.name;
            age = joko.Value.age;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var value=$"Your name is {name} and your age is {age}";
            _logger.LogInformation(value);
            return Ok( new {value});
            
        }
    }
}
