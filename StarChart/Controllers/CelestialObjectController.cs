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

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects.Find(id);
            if (celestialObject == null)
                return NotFound();
            celestialObject.Satellites = 
                _context.CelestialObjects.Where(e => e.OrbitedObjectId == id).ToList();
            return Ok(celestialObject);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var celestialObjects = _context.CelestialObjects.Where(e => e.Name == name);
            if (celestialObjects == null)
                return NotFound();
            foreach (var celestialObject in celestialObjects)
            {
                celestialObject.Satellites = 
                    _context.CelestialObjects.Where(e => e.OrbitedObjectId == celestialObject.Id)
                    .ToList();
            }
            return Ok(celestialObjects);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Satelites = _context.CelestialObjects.ToList();
            foreach (var celetialObject in Satelites)
            {
                celetialObject.Satellites =
                    _context.CelestialObjects.Where(e => e.OrbitedObjectId == celetialObject.Id)
                    .ToList();
            }
            return Ok(Satelites);
        }
    }
}
