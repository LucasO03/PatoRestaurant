using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatoRestaurant.Data;
using PatoRestaurant.Models;

namespace PatoRestaurant.Controllers
{
    public class StatusResevationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatusResevationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StatusResevation
        public async Task<IActionResult> Index()
        {
              return View(await _context.StatusResarvations.ToListAsync());
        }

        // GET: StatusResevation/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.StatusResarvations == null)
            {
                return NotFound();
            }

            var statusReservation = await _context.StatusResarvations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusReservation == null)
            {
                return NotFound();
            }

            return View(statusReservation);
        }

        // GET: StatusResevation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusResevation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StatusReservation statusReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusReservation);
        }

        // GET: StatusResevation/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.StatusResarvations == null)
            {
                return NotFound();
            }

            var statusReservation = await _context.StatusResarvations.FindAsync(id);
            if (statusReservation == null)
            {
                return NotFound();
            }
            return View(statusReservation);
        }

        // POST: StatusResevation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,Name")] StatusReservation statusReservation)
        {
            if (id != statusReservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusReservationExists(statusReservation.Id))
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
            return View(statusReservation);
        }

        // GET: StatusResevation/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.StatusResarvations == null)
            {
                return NotFound();
            }

            var statusReservation = await _context.StatusResarvations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusReservation == null)
            {
                return NotFound();
            }

            return View(statusReservation);
        }

        // POST: StatusResevation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.StatusResarvations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StatusResarvations'  is null.");
            }
            var statusReservation = await _context.StatusResarvations.FindAsync(id);
            if (statusReservation != null)
            {
                _context.StatusResarvations.Remove(statusReservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusReservationExists(byte id)
        {
          return _context.StatusResarvations.Any(e => e.Id == id);
        }
    }
}
