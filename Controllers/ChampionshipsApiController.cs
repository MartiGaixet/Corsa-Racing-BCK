using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CorsaRacing.Models;
using CorsaRacing.Services;

namespace CorsaRacing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipsApiController : ControllerBase
    {
        private readonly IChampionshipService _championshipService;

        public ChampionshipsApiController(IChampionshipService championshipService)
        {
            _championshipService = championshipService;
        }

        // GET: api/ChampionshipsApi
        [HttpGet]
        public async Task<IActionResult> GetAllChampionships()
        {
            var championships = await _championshipService.GetAllChampionships(); // Asegurar `await`
            return Ok(championships);
        }


        // GET: api/ChampionshipsApi/5
        [HttpGet("{id}")]
        public ActionResult<Championship> GetChampionship(int id)
        {
            var championship = _championshipService.GetChampionshipById(id);
            if (championship == null)
            {
                return NotFound();
            }
            return Ok(championship);
        }

        // POST: api/ChampionshipsApi
        [HttpPost]
        public IActionResult PostChampionship([FromBody] Championship championship)
        {
            if (championship == null)
            {
                return BadRequest("Invalid championship data.");
            }

            _championshipService.AddChampionship(championship);
            return CreatedAtAction(nameof(GetChampionship), new { id = championship.Id }, championship);
        }

        // PUT: api/ChampionshipsApi/5
        [HttpPut("{id}")]
        public IActionResult PutChampionship(int id, [FromBody] Championship championship)
        {
            if (championship == null || id != championship.Id)
            {
                return BadRequest("Invalid championship data.");
            }

            var existingChampionship = _championshipService.GetChampionshipById(id);
            if (existingChampionship == null)
            {
                return NotFound();
            }

            _championshipService.UpdateChampionship(championship);
            return NoContent();
        }

        // DELETE: api/ChampionshipsApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteChampionship(int id)
        {
            var existingChampionship = _championshipService.GetChampionshipById(id);
            if (existingChampionship == null)
            {
                return NotFound();
            }

            _championshipService.DeleteChampionship(id);
            return NoContent();
        }
    }
}