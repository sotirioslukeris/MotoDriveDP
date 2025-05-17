using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPMotoDrive.Data;
using ASPMotoDrive.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using ASPMotoDrive.Migrations;
using ASPMotoDrive.Data.Models.Cookies;

namespace ASPMotoDrive.Controllers
{

    [Authorize]
    public class OrdersController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<User> userManger)
        {
            _context = context;
            _userManager = userManger;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Motorcycles);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Motorcycles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

      
        public IActionResult ShoppingCart()
        {
            var cart = CookieHelper.GetObject<Cart>(Request, "Cart") ?? new Cart();

            List<Motorcycle> cartItems = cart.Items;

            return View(cartItems);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShoppingCart([Bind("MotorcycleId,UserId,DateRegister")] Order order)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("FinalisedOrder");
            }

            return View();
        }

       


        public IActionResult FinalisedOrder()
        {
            return View();
        }


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["MotorcycleId"] = new SelectList(_context.Motorcycles, "Id", "Name", order.MotorcycleId);
            return View(order);
        }


        
        public IActionResult AddToCart(int id)
        { 
            // Get cart from cookie or create new
            var cart = CookieHelper.GetObject<Cart>(Request, "Cart") ?? new Cart();

            var motorcycle = _context.Motorcycles.FirstOrDefault(x => x.Id == id);

            // Add new motorcycle to cart
            cart.Items.Add(motorcycle);
            

            // Save updated cart back to cookie (expires in 7 days)
            CookieHelper.SetObject(Response, "Cart", cart, 7);

            return RedirectToAction("ShoppingCart");
        }




        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MotorcycleId,UserId,Description,Quantity,DateRegister")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    order.DateRegister = DateTime.Now;
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["MotorcycleId"] = new SelectList(_context.Motorcycles, "Id", "Name", order.MotorcycleId);
            return View(order);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id, List<Motorcycle> cart)
        {
            
            var item = cart.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            return View("ShoppingCart",cart);
        }


        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Motorcycles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
