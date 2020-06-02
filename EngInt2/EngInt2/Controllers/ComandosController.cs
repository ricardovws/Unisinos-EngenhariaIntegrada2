using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EngInt2.Models;

namespace EngInt2.Controllers
{
    public class ComandosController : Controller
    {
        private readonly EngInt2Context _context;

        public ComandosController(EngInt2Context context)
        {
            _context = context;
        }

        // GET: Comandos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comandos.ToListAsync());
        }

        // GET: Comandos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comandos = await _context.Comandos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comandos == null)
            {
                return NotFound();
            }

            return View(comandos);
        }

        // GET: Comandos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comandos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeComponente,Ligado,Desligado,Status,Status_Enum")] Comandos comandos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comandos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comandos);
        }

        // GET: Comandos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comandos = await _context.Comandos.FindAsync(id);
            if (comandos == null)
            {
                return NotFound();
            }
            return View(comandos);
        }

        // POST: Comandos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeComponente,Ligado,Desligado,Status,Status_Enum")] Comandos comandos)
        {
            if (id != comandos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comandos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandosExists(comandos.Id))
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
            return View(comandos);
        }

        // GET: Comandos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comandos = await _context.Comandos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comandos == null)
            {
                return NotFound();
            }

            return View(comandos);
        }

        // POST: Comandos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comandos = await _context.Comandos.FindAsync(id);
            _context.Comandos.Remove(comandos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandosExists(int id)
        {
            return _context.Comandos.Any(e => e.Id == id);
        }
    }
}
