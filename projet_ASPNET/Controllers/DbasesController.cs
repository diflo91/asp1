using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet_ASPNET.Data;
using projet_ASPNET.Models;

namespace projet_ASPNET.Controllers
{
    public class DbasesController : Controller
    {
        private readonly projet_ASPNETContext _context;

        public DbasesController(projet_ASPNETContext context)
        {
            _context = context;
        }

        // GET: Dbases
        public async Task<IActionResult> Index()
        {
              return _context.Dbase != null ? 
                          View(await _context.Dbase.ToListAsync()) :
                          Problem("Entity set 'projet_ASPNETContext.Dbase'  is null.");
        }

        // GET: Dbases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dbase == null)
            {
                return NotFound();
            }

            var dbase = await _context.Dbase
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dbase == null)
            {
                return NotFound();
            }

            return View(dbase);
        }

        // GET: Dbases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dbases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titre,Contenu")] Article dbase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbase);
        }

        // GET: Dbases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dbase == null)
            {
                return NotFound();
            }

            var dbase = await _context.Dbase.FindAsync(id);
            if (dbase == null)
            {
                return NotFound();
            }
            return View(dbase);
        }

        // POST: Dbases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titre,Contenu")] Article dbase)
        {
            if (id != dbase.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbaseExists(dbase.ID))
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
            return View(dbase);
        }

        // GET: Dbases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dbase == null)
            {
                return NotFound();
            }

            var dbase = await _context.Dbase
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dbase == null)
            {
                return NotFound();
            }

            return View(dbase);
        }

        // POST: Dbases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dbase == null)
            {
                return Problem("Entity set 'projet_ASPNETContext.Dbase'  is null.");
            }
            var dbase = await _context.Dbase.FindAsync(id);
            if (dbase != null)
            {
                _context.Dbase.Remove(dbase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbaseExists(int id)
        {
          return (_context.Dbase?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
