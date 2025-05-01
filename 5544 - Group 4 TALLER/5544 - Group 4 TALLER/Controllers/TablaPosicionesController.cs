using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _5544___Group_4_TALLER.Models;

namespace _5544___Group_4_TALLER.Controllers
{
    public class TablaPosicionesController : Controller
    {
        private readonly DbGrupo4 _context;

        public TablaPosicionesController(DbGrupo4 context)
        {
            _context = context;
        }

        // GET: TablaPosiciones
        public async Task<IActionResult> Index()
        {
            var dbGrupo4 = _context.TablaPosiciones.Include(t => t.Equipo);
            return View(await dbGrupo4.ToListAsync());
        }

        // GET: TablaPosiciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPosiciones = await _context.TablaPosiciones
                .Include(t => t.Equipo)
                .FirstOrDefaultAsync(m => m.TablaID == id);
            if (tablaPosiciones == null)
            {
                return NotFound();
            }

            return View(tablaPosiciones);
        }

        // GET: TablaPosiciones/Create
        public IActionResult Create()
        {
            ViewData["EquipoID"] = new SelectList(_context.Equipo, "EquipoID", "Nombre");
            return View();
        }

        // POST: TablaPosiciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TablaID,Puntos,PartidosJugados,DiferenciaGol,PosicionActual,EquipoID")] TablaPosiciones tablaPosiciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablaPosiciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoID"] = new SelectList(_context.Equipo, "EquipoID", "Nombre", tablaPosiciones.EquipoID);
            return View(tablaPosiciones);
        }

        // GET: TablaPosiciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPosiciones = await _context.TablaPosiciones.FindAsync(id);
            if (tablaPosiciones == null)
            {
                return NotFound();
            }
            ViewData["EquipoID"] = new SelectList(_context.Equipo, "EquipoID", "Nombre", tablaPosiciones.EquipoID);
            return View(tablaPosiciones);
        }

        // POST: TablaPosiciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TablaID,Puntos,PartidosJugados,DiferenciaGol,PosicionActual,EquipoID")] TablaPosiciones tablaPosiciones)
        {
            if (id != tablaPosiciones.TablaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaPosiciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaPosicionesExists(tablaPosiciones.TablaID))
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
            ViewData["EquipoID"] = new SelectList(_context.Equipo, "EquipoID", "Nombre", tablaPosiciones.EquipoID);
            return View(tablaPosiciones);
        }

        // GET: TablaPosiciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPosiciones = await _context.TablaPosiciones
                .Include(t => t.Equipo)
                .FirstOrDefaultAsync(m => m.TablaID == id);
            if (tablaPosiciones == null)
            {
                return NotFound();
            }

            return View(tablaPosiciones);
        }

        // POST: TablaPosiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaPosiciones = await _context.TablaPosiciones.FindAsync(id);
            if (tablaPosiciones != null)
            {
                _context.TablaPosiciones.Remove(tablaPosiciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaPosicionesExists(int id)
        {
            return _context.TablaPosiciones.Any(e => e.TablaID == id);
        }
    }
}
