using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CorsaRacing.Models;
using CorsaRacing.Services;

namespace CorsaRacing.Controllers
{
    public class RacesController : Controller
    {
        private readonly IRaceService _raceService;

        public RacesController(IRaceService raceservice)
        {
            _raceService = raceservice;
        }

        // GET: Races
        public async Task<IActionResult> Index()
        {
            var races = _raceService.GetAllRaces();
            return View(races);
        }

        // GET: Races/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var race = _raceService.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }
            return View(race);
        }

        // GET: Races/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Races/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Circuit,Car,Date")] Race race)
        {
            if (ModelState.IsValid)
            {
                _raceService.AddRace(race);

                return RedirectToAction(nameof(Index));
            }
            return View(race);
        }

        // GET: Races/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = _raceService.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }
            return View(race);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Circuit,Car,Date")] Race race)
        {
            if (id != race.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _raceService.UpdateRace(race);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceExists(race.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(race);
        }

        // GET: Races/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var race = _raceService.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var race = _raceService.GetRaceById(id);
            if (race != null)
            {
                _raceService.DeleteRace(race.Id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RaceExists(int id)
        {
            return _raceService.GetRaceById(id).Id == id;
        }
    }
}
