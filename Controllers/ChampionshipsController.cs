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
    public class ChampionshipsController : Controller
    {
        private readonly IChampionshipService _championshipService;

        public ChampionshipsController(IChampionshipService championshipService)
        {
            _championshipService = championshipService;
        }

        // GET: Championships
        public async Task<IActionResult> Index()
        {
            var championships = _championshipService.GetAllChampionships();
            return View(championships);
        }

        // GET: Championships/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var championship = _championshipService.GetChampionshipById(id);
            if (championship == null)
            {
                return NotFound();
            }
            return View(championship);
        }

        // GET: Championships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Championships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Championship championship)
        {

            if (ModelState.IsValid)
            {
                _championshipService.AddChampionship(championship);

                return RedirectToAction(nameof(Index));
            }
            return View(championship);
        }

        // GET: Championships/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championship = _championshipService.GetChampionshipById(id);
            if (championship == null)
            {
                return NotFound();
            }
            return View(championship);
        }

        // POST: Championships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Championship championship)
        {
            if (id != championship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _championshipService.UpdateChampionship(championship);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampionshipExists(championship.Id))
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
            return View(championship);
        }

        // GET: Championships/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championship = _championshipService.GetChampionshipById(id);
            if (championship == null)
            {
                return NotFound();
            }

            return View(championship);
        }

        // POST: Championships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var championship = _championshipService.GetChampionshipById(id);
            if (championship != null)
            {
                _championshipService.DeleteChampionship(championship.Id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ChampionshipExists(int id)
        {
            return _championshipService.GetChampionshipById(id).Id == id;
        }
    }
}
