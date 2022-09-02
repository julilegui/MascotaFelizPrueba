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
    public class HistoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Historia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Historia.ToListAsync());
        }

        // GET: Historia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historia = await _context.Historia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // GET: Historia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaInicial")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historia);
        }

        // GET: Historia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historia = await _context.Historia.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }
            return View(historia);
        }

        // POST: Historia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaInicial")] Historia historia)
        {
            if (id != historia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaExists(historia.Id))
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
            return View(historia);
        }

        // GET: Historia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historia = await _context.Historia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // POST: Historia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historia = await _context.Historia.FindAsync(id);
            _context.Historia.Remove(historia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaExists(int id)
        {
            return _context.Historia.Any(e => e.Id == id);
        }
    }
}
