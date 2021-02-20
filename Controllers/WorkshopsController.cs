using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiExercise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkshopsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WorkshopsController> _logger;

        public WorkshopsController(ILogger<WorkshopsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Workshop> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Workshop
            {
                Id = index,
                Status = "Postponed",
                Name = "Something"
            })
            .ToArray();
        }
    }
}
