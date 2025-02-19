using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPMotoDrive.Migrations;
using ASPMotoDrive.Data;
using Microsoft.AspNetCore.Identity;
using ASPMotoDrive.Models;

namespace ASPMotoDrive.Controllers
{
    public class OrdersController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            {



            }
        }


    }
}
