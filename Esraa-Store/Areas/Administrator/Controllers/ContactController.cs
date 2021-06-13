using Esraa_Store.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext db;
        public ContactController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult AllContact()
        {
            var obj = db.contacts.ToList();
            return View(obj);
        }
    }
}
