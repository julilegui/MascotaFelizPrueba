using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MascotaFelizPrueba.Data;
using MascotaFelizPrueba.Models;

namespace MascotaFelizPrueba.Controllers
{
    public class VisitaPyPController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitaPyPController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VisitaPyP
        public async Task<IActionResult> Index()
        {
            return View(await _context.VisitaPyP.ToListAsync());
        }

        // GET: VisitaPyP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaPyP = await _context.VisitaPyP
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitaPyP == null)
            {
                return NotFound();
            }

            return View(visitaPyP);
        }

        // GET: VisitaPyP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VisitaPyP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaVisita,Temperatura,Peso,FrecuenciaRespiratoria,FrecuenciaCardiaca,EstadoAnimo,IdVeterinario,Recomendaciones")] VisitaPyP visitaPyP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitaPyP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitaPyP);
        }

        // GET: VisitaPyP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaPyP = await _context.VisitaPyP.FindAsync(id);
            if (visitaPyP == null)
            {
                return NotFound();
            }
            return View(visitaPyP);
        }

        // POST: VisitaPyP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaVisita,Temperatura,Peso,FrecuenciaRespiratoria,FrecuenciaCardiaca,EstadoAnimo,IdVeterinario,Recomendaciones")] VisitaPyP visitaPyP)
        {
            if (id != visitaPyP.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitaPyP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaPyPExists(visitaPyP.Id))
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
            return View(visitaPyP);
        }

        // GET: VisitaPyP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaPyP = await _context.VisitaPyP
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitaPyP == null)
            {
                return NotFound();
            }

            return View(visitaPyP);
        }

        // POST: VisitaPyP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitaPyP = await _context.VisitaPyP.FindAsync(id);
            _context.VisitaPyP.Remove(visitaPyP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaPyPExists(int id)
        {
            return _context.VisitaPyP.Any(e => e.Id == id);
        }
    }
}
