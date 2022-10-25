using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var Satelites = _context.CelestialObjects.Where(obj => obj.Id == na)
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Satelites = _context.CelestialObjects;
            return Ok(Satelites);
        }
    }
}
