using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoTomaAsistencia.Models;

namespace ProyectoTomaAsistencia.Controllers
{
    public class AsistenciaController : Controller
    {
        private readonly AsistenciaDbContext _context;

        public AsistenciaController(AsistenciaDbContext context)
        {
            _context = context;
        }

        // GET: Asistencia
        public async Task<IActionResult> Index()
        {
            return View(await _context.AsistenciaModel.ToListAsync());
        }

        // GET: Asistencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaModel = await _context.AsistenciaModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (asistenciaModel == null)
            {
                return NotFound();
            }

            return View(asistenciaModel);
        }

        // GET: Asistencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asistencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido")] AsistenciaModel asistenciaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistenciaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asistenciaModel);
        }

        // GET: Asistencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaModel = await _context.AsistenciaModel.SingleOrDefaultAsync(m => m.Id == id);
            if (asistenciaModel == null)
            {
                return NotFound();
            }
            return View(asistenciaModel);
        }

        // POST: Asistencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido")] AsistenciaModel asistenciaModel)
        {
            if (id != asistenciaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistenciaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaModelExists(asistenciaModel.Id))
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
            return View(asistenciaModel);
        }

        // GET: Asistencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistenciaModel = await _context.AsistenciaModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (asistenciaModel == null)
            {
                return NotFound();
            }

            return View(asistenciaModel);
        }

        // POST: Asistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistenciaModel = await _context.AsistenciaModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.AsistenciaModel.Remove(asistenciaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaModelExists(int id)
        {
            return _context.AsistenciaModel.Any(e => e.Id == id);
        }
    }
}
