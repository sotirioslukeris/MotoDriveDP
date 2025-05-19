using ASPMotoDrive.Data;
using ASPMotoDrive.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPMotoDrive.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            string currentUser = User.Identity.Name;

            var cartItems = _context.CartItems.Include(x => x.Motorcycles).Include(x=>x.Motorcycles.Models).
                Include(x=>x.Motorcycles.Models.Brands).Where(x => x.User == currentUser).ToList();

            if(cartItems==null)
            {
                return NotFound();
            }   

            return View(cartItems);
        }

        

        
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddToCart([Bind("MotorcycleId,User")] CartItem cartItem)
        {
            if (cartItem == null)
            {
                return RedirectToAction("Details", "Motorcycle"); 
            }

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            cartItem.User = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _context.CartItems.Add(cartItem);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Details", "Motorcycle");
        }




        // POST: CartController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
