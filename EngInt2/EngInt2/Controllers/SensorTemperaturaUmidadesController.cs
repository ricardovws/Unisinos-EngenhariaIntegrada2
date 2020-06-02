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
    public class SensorTemperaturaUmidadesController : Controller
    {
        private readonly EngInt2Context _context;

        public SensorTemperaturaUmidadesController(EngInt2Context context)
        {
            _context = context;
        }

        // GET: SensorTemperaturaUmidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.SensorTemperaturaUmidade.ToListAsync());
        }

        // GET: SensorTemperaturaUmidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorTemperaturaUmidade = await _context.SensorTemperaturaUmidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sensorTemperaturaUmidade == null)
            {
                return NotFound();
            }

            return View(sensorTemperaturaUmidade);
        }

        // GET: SensorTemperaturaUmidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SensorTemperaturaUmidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperatura,Umidade")] SensorTemperaturaUmidade sensorTemperaturaUmidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sensorTemperaturaUmidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sensorTemperaturaUmidade);
        }

        // GET: SensorTemperaturaUmidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorTemperaturaUmidade = await _context.SensorTemperaturaUmidade.FindAsync(id);
            if (sensorTemperaturaUmidade == null)
            {
                return NotFound();
            }
            return View(sensorTemperaturaUmidade);
        }

        // POST: SensorTemperaturaUmidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperatura,Umidade")] SensorTemperaturaUmidade sensorTemperaturaUmidade)
        {
            if (id != sensorTemperaturaUmidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sensorTemperaturaUmidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SensorTemperaturaUmidadeExists(sensorTemperaturaUmidade.Id))
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
            return View(sensorTemperaturaUmidade);
        }

        // GET: SensorTemperaturaUmidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorTemperaturaUmidade = await _context.SensorTemperaturaUmidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sensorTemperaturaUmidade == null)
            {
                return NotFound();
            }

            return View(sensorTemperaturaUmidade);
        }

        // POST: SensorTemperaturaUmidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sensorTemperaturaUmidade = await _context.SensorTemperaturaUmidade.FindAsync(id);
            _context.SensorTemperaturaUmidade.Remove(sensorTemperaturaUmidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SensorTemperaturaUmidadeExists(int id)
        {
            return _context.SensorTemperaturaUmidade.Any(e => e.Id == id);
        }
    }
}
