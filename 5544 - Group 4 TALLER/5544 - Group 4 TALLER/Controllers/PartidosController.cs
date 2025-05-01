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
    public class PartidosController : Controller
    {
        private readonly DbGrupo4 _context;

        public PartidosController(DbGrupo4 context)
        {
            _context = context;
        }

        // GET: Partidos
        public async Task<IActionResult> Index()
        {
            var dbGrupo4 = _context.Partido.Include(p => p.Equipo);
            return View(await dbGrupo4.ToListAsync());
        }

        // GET: Partidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partido
                .Include(p => p.Equipo)
                .FirstOrDefaultAsync(m => m.PartidoID == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // GET: Partidos/Create
        public IActionResult Create()
        {
            ViewData["EquipoID"] = new SelectList(_context.Equipo, "EquipoID", "Nombre");
            return View();
        }

        // POST: Partidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartidoID,Jugados,Ganados,Empatados,Perdidos,EquipoID")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoID"] = new SelectList(_context.Equipo, "EquipoID", "Nombre", partido.EquipoID);
            return View(partido);
        }

        // GET: Partidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partido.FindAsync(id);
            if (partido == null)
            {
                return NotFound();
            }
            ViewData["EquipoID"] = new SelectList(_context.Equipo, "EquipoID", "Nombre", partido.EquipoID);
            return View(partido);
        }

        // POST: Partidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartidoID,Jugados,Ganados,Empatados,Perdidos,EquipoID")] Partido partido)
        {
            if (id != partido.PartidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidoExists(partido.PartidoID))
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
            ViewData["EquipoID"] = new SelectList(_context.Equipo, "EquipoID", "Nombre", partido.EquipoID);
            return View(partido);
        }

        // GET: Partidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partido
                .Include(p => p.Equipo)
                .FirstOrDefaultAsync(m => m.PartidoID == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // POST: Partidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partido = await _context.Partido.FindAsync(id);
            if (partido != null)
            {
                _context.Partido.Remove(partido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidoExists(int id)
        {
            return _context.Partido.Any(e => e.PartidoID == id);
        }
    }
}
