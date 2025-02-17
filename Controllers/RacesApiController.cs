using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CorsaRacing.Models;
using CorsaRacing.Services;

namespace CorsaRacing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesApiController : ControllerBase
    {
        private readonly IRaceService _raceService;

        public RacesApiController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        // GET: api/RacesApi
        [HttpGet]
        public ActionResult<IEnumerable<Race>> GetRaces()
        {
            var races = _raceService.GetAllRaces();
            return Ok(races);
        }

        // GET: api/RacesApi/5
        [HttpGet("{id}")]
        public ActionResult<Race> GetRace(int id)
        {
            var race = _raceService.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }
            return Ok(race);
        }

        // POST: api/RacesApi
        [HttpPost]
        public IActionResult PostRace([FromBody] Race race)
        {
            if (race == null)
            {
                return BadRequest("Invalid race data.");
            }

            _raceService.AddRace(race);
            return CreatedAtAction(nameof(GetRace), new { id = race.Id }, race);
        }

        // PUT: api/RacesApi/5
        [HttpPut("{id}")]
        public IActionResult PutRace(int id, [FromBody] Race race)
        {
            if (race == null || id != race.Id)
            {
                return BadRequest("Invalid race data.");
            }

            var existingRace = _raceService.GetRaceById(id);
            if (existingRace == null)
            {
                return NotFound();
            }

            _raceService.UpdateRace(race);
            return NoContent();
        }

        // DELETE: api/RacesApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRace(int id)
        {
            var existingRace = _raceService.GetRaceById(id);
            if (existingRace == null)
            {
                return NotFound();
            }

            _raceService.DeleteRace(id);
            return NoContent();
        }

        [HttpGet("byChampionship/{championshipId}")]
        public async Task<ActionResult<List<Race>>> GetRacesByChampionship(int championshipId)
        {
            var races = await _raceService.GetRacesByChampionshipId(championshipId);
            if (races == null || !races.Any())
            {
                return NotFound("No se encontraron carreras para este campeonato.");
            }
            return Ok(races);
        }
    }
}

