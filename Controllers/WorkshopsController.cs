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
                Status = "Scheduled",
                Name = "Anything really"
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

        [HttpPost]
        public IEnumerable<Workshop> CreateWorkshop(Workshop workshop)
        {
            workshop.Id = workshops.Count + 1;
            workshops.Add(workshop);
            return workshops;
        }

        [HttpPut("{id}")]
        public IEnumerable<Workshop> updateWorkshop(int id, Workshop workshop)
        {
            int foundWorkshopIndex = workshops.FindIndex(workshop => workshop.Id == id);
            workshop.Id = id;
            workshops[foundWorkshopIndex] = workshop;
            return workshops;
        }
    }
}
