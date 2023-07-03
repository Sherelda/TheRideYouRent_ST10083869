using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheRideYouRent_ST10083869.Models;

namespace TheRideYouRent_ST10083869.Controllers
{
    public class ReturnCarController : Controller
    {
        private readonly TheRideYouRentContext _context;

        public ReturnCarController(TheRideYouRentContext context)
        {
            _context = context;
        }

        // GET: ReturnCar
        public async Task<IActionResult> Index()
        {
            var theRideYouRentContext = _context.ReturnCars.Include(r => r.CarNoNavigation).Include(r => r.Driver).Include(r => r.Inspector);
            return View(await theRideYouRentContext.ToListAsync());
        }

        // GET: ReturnCar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReturnCars == null)
            {
                return NotFound();
            }

            var returnCar = await _context.ReturnCars
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .Include(r => r.Inspector)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (returnCar == null)
            {
                return NotFound();
            }

            return View(returnCar);
        }

        // GET: ReturnCar/Create
        public IActionResult Create()
        {
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId");
            ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId");
            return View();
        }

        // POST: ReturnCar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnId,CarNo,InspectorId,DriverId,DriverName,ReturnDate,ElapsedDate,Fine")] ReturnCar returnCar)
        {
            if (ModelState.IsValid)
            {
                _context.ReturnCars.Add(returnCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo", returnCar.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", returnCar.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId", returnCar.InspectorId);
            return View(returnCar);
        }

        // GET: ReturnCar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReturnCars == null)
            {
                return NotFound();
            }

            var returnCar = await _context.ReturnCars.FindAsync(id);
            if (returnCar == null)
            {
                return NotFound();
            }
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo", returnCar.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", returnCar.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId", returnCar.InspectorId);
            return View(returnCar);
        }

        // POST: ReturnCar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnId,CarNo,InspectorId,DriverId,DriverName,ReturnDate,ElapsedDate,Fine")] ReturnCar returnCar)
        {
            if (id != returnCar.ReturnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnCarExists(returnCar.ReturnId))
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
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo", returnCar.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", returnCar.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId", returnCar.InspectorId);
            return View(returnCar);
        }

        // GET: ReturnCar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReturnCars == null)
            {
                return NotFound();
            }

            var returnCar = await _context.ReturnCars
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .Include(r => r.Inspector)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (returnCar == null)
            {
                return NotFound();
            }

            return View(returnCar);
        }

        // POST: ReturnCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReturnCars == null)
            {
                return Problem("Entity set 'TheRideYouRentContext.ReturnCars'  is null.");
            }
            var returnCar = await _context.ReturnCars.FindAsync(id);
            if (returnCar != null)
            {
                _context.ReturnCars.Remove(returnCar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnCarExists(int id)
        {
          return (_context.ReturnCars?.Any(e => e.ReturnId == id)).GetValueOrDefault();
        }
    }
}
