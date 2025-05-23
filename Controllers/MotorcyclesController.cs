﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPMotoDrive.Data;
using ASPMotoDrive.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Drawing2D;


namespace ASPMotoDrive.Controllers
{

    public class MotorcyclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotorcyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Motorcycles
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Motorcycles.Include(m => m.Models);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Motorcycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorcycle = await _context.Motorcycles
                .Include(m => m.Models).Include(m => m.Models.Brands)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorcycle == null)
            {
                return NotFound();
            }

            return View(motorcycle);
        }

        // GET: Motorcycles/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name");
            return View();
        }

        // POST: Motorcycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ModelId,TypeUsage,Mileage,Colour,CatalogueNumber,EnginePower,ImageURL,Price,TypeMotor,Description,Category")] Motorcycle motorcycle)
        {
            motorcycle.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(motorcycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
           
        }



        public IActionResult NewMotorcycles(double? price, string? brand, int? year)
        {
            var motorcycles = _context.Motorcycles.Include(x => x.Models).
               Include(x => x.Models.Brands).Where(x => x.TypeUsage.Equals(TypeUsage.Нов)).ToList();

            if (motorcycles == null)
            {
                return NotFound();
            }

           motorcycles = Filters(motorcycles,price, brand, year, null);

            ViewBag.Brands = _context.Brands.ToList();
            return View(motorcycles);
        }

        public IActionResult UsedMotorcycles(double? price, string? brand, int? year)
        {
            var motorcycles = _context.Motorcycles.Include(x => x.Models).
              Include(x => x.Models.Brands).Where(x => x.TypeUsage.Equals(TypeUsage.Употребяван))
              .ToList();
            if (motorcycles == null)
            {
                return NotFound();
            }

            ViewBag.Brands = _context.Brands.ToList();
            motorcycles = Filters(motorcycles,price, brand, year, null);
            return View(motorcycles);
        }




        // GET: Motorcycles/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var motorcycle = await _context.Motorcycles.FindAsync(id);

            if (motorcycle == null)
            {
                return NotFound();
            }

            motorcycle.LastUpdate = DateTime.Now;
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", motorcycle.ModelId);
            return View(motorcycle);
        }
        

        public List<Motorcycle> Filters(List<Motorcycle> motorcycles,double? price, string? brand, int? year, string? typeUsage)
        {
           

            if (price.HasValue)
            {

                motorcycles = motorcycles.Where(x => x.Price <= price.Value).ToList();
            }

            if (!brand.IsNullOrEmpty())
            {
                if (brand == "all")
                {

                }
                else
                {
                    motorcycles = motorcycles.Where(x => x.Models.Brands.Name == brand).ToList();
                }

                if (!typeUsage.IsNullOrEmpty())
                {
                    if (typeUsage == "Нов")
                    {
                        motorcycles = motorcycles.Where(x => x.TypeUsage.Equals(TypeUsage.Нов)).ToList();
                    }
                    else
                    {
                        motorcycles = motorcycles.Where(x => x.TypeUsage.Equals(TypeUsage.Употребяван)).ToList();

                    }

                }
            }
            if (year.HasValue)
            {
                motorcycles = motorcycles.Where(x => x.Models.YearOfManuf == year).ToList();
            }

            return motorcycles;
        }

        public IActionResult Models(double? price, string? brand, int? year, string? typeUsage)
        {
            var motorcycles = _context.Motorcycles.Include(m => m.Models)
             .Include(m => m.Models.Brands).ToList();

            motorcycles = Filters(motorcycles,price,brand,year,typeUsage);

            ViewBag.Brands = _context.Brands.ToList();

            return View(motorcycles);


        }



        // POST: Motorcycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelId,TypeUsage,Mileage,Colour,CatalogueNumber,EnginePower,ImageURL,Price,TypeMotor,Description,Category,Mileage")] Motorcycle motorcycle)
        {
            motorcycle.LastUpdate = DateTime.Now;
            if (id != motorcycle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorcycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorcycleExists(motorcycle.Id))
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
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", motorcycle.ModelId);
            return View(motorcycle);
        }

        // GET: Motorcycles/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorcycle = await _context.Motorcycles
                .Include(m => m.Models)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorcycle == null)
            {
                return NotFound();
            }

            return View(motorcycle);
        }

        // POST: Motorcycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motorcycle = await _context.Motorcycles.FindAsync(id);
            if (motorcycle != null)
            {
                _context.Motorcycles.Remove(motorcycle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotorcycleExists(int id)
        {
            return _context.Motorcycles.Any(e => e.Id == id);
        }
    }
}
