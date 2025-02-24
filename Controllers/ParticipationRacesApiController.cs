using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorsaRacing.Models;
using CorsaRacing.Services;

namespace CorsaRacing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipationRacesApiController : ControllerBase
    {
        private readonly IParticipationRaceService _participationRaceService;

        public ParticipationRacesApiController(IParticipationRaceService participationRaceService)
        {
            _participationRaceService = participationRaceService;
        }

        // GET: api/ParticipationRacesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipationRace>>> GetAll()
        {
            return Ok(await _participationRaceService.GetAllAsync());
        }

        // GET: api/ParticipationRacesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipationRace>> GetById(int id)
        {
            var participation = await _participationRaceService.GetByIdAsync(id);
            if (participation == null)
                return NotFound();
            return Ok(participation);
        }

        // POST: api/ParticipationRacesApi
        [HttpPost]
        public async Task<IActionResult> AddParticipation([FromBody] ParticipationRace participation)
        {
            if (participation == null)
                return BadRequest("Datos inválidos.");

            if (participation.UserId == 0 || participation.RaceId == 0)
                return BadRequest("Faltan los IDs de usuario o carrera.");

            bool created = await _participationRaceService.AddParticipationAsync(participation.UserId, participation.RaceId);
            if (!created)
                return Conflict("El usuario ya está registrado en esta carrera.");

            return Ok("Participación creada exitosamente.");
        }


        // DELETE: api/ParticipationRacesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipation(int id)
        {
            await _participationRaceService.DeleteParticipationAsync(id);
            return NoContent();
        }
    }
}

