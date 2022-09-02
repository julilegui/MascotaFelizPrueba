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
    public class DuenoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DuenoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dueno
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dueno.ToListAsync());
        }

        // GET: Dueno/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();

        }

        // GET: Dueno/ShowSearchResults/Falta crear este metodo. Terminarlo!
        public async Task<IActionResult> ShowSearchResults(String Correo)
        {
            return View();

        }



        // GET: Dueno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // GET: Dueno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dueno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Correo,Id,Identificacion,Nombres,Apellidos,Direccion,Telefono")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dueno);
        }

        // GET: Dueno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno.FindAsync(id);
            if (dueno == null)
            {
                return NotFound();
            }
            return View(dueno);
        }

        // POST: Dueno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Correo,Id,Identificacion,Nombres,Apellidos,Direccion,Telefono")] Dueno dueno)
        {
            if (id != dueno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenoExists(dueno.Id))
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
            return View(dueno);
        }

        // GET: Dueno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // POST: Dueno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dueno = await _context.Dueno.FindAsync(id);
            _context.Dueno.Remove(dueno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoExists(int id)
        {
            return _context.Dueno.Any(e => e.Id == id);
        }
    }
}
