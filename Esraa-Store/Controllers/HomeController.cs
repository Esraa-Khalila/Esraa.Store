using Esraa_Store.Data;
using Esraa_Store.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment _webHostEnvironment, ApplicationDbContext _db)
        {
            _logger = logger;
            webHostEnvironment = _webHostEnvironment;
            db = _db;
        }

        public IActionResult Index()
        {
           
            
            return View();
        }
        public IActionResult Like(int id)
        {
            Featured update = db.featureds.ToList().Find(x => x.FeaturedId == id);
            update.Like += 1;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Contact(Contact obj)
        {
            if (ModelState.IsValid)
            {
                db.contacts.Add(obj);
                db.SaveChanges();

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
