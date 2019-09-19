using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BringYourOwnDeviceWatcher.Models;
using Microsoft.EntityFrameworkCore;

namespace BringYourOwnDeviceWatcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly NmapRunContext _context;

        public HomeController(NmapRunContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.AmountOfHosts = _context.Hosts.Count();

            if (_context.Hosts.Count() > 0)
            {
                List<Host> hosts = _context.Hosts.Include(b => b.Hostname).Include(b => b.Address).ToList();
                ViewBag.Hosts = hosts;
            }
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
