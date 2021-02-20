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
        private static List<Workshop> workshops = Enumerable.Range(1, 5).Select(index => new Workshop
            {
                Id = index,
                Status = "Postponed",
                Name = "Wander"
            }).ToList();

        private readonly ILogger<WorkshopsController> _logger;

        public WorkshopsController(ILogger<WorkshopsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Workshop> GetWorkshops()
        {
            return workshops;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Workshop> DeleteWorkshops(int id)
        {
            workshops.RemoveAll(workshop => workshop.Id == id);
            return workshops;
        }
    }
}
