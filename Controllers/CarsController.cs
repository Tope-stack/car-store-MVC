using CarsMVC.Data;
using CarsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsMVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsDbContext _context;    

        public CarsController(CarsDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Car.ToListAsync());
        }

        // GET: Cars/Details

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Manufacturer,Name,Year,Price,Engine,ImageUrl")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }


        // GET: Cars/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Manufacturer,Name,Year,Price,Engine,ImageUrl")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;  
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        private bool CarExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: Cars/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Car == null)
            {
                return Problem("Entity set 'CarsDbContext.Car' is null.");
            }

            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                _context.Car.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
