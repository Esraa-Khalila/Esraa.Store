using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Esraa_Store.Data;
using Esraa_Store.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Esraa_Store.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Esraa_Store.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class LastestProesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
       

        public LastestProesController(ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        // GET: Administrator/LastestProes
        public async Task<IActionResult> Index()
        {
            return View(await _context.lastestPros.ToListAsync());
        }

        // GET: Administrator/LastestProes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lastestPro = await _context.lastestPros
                .FirstOrDefaultAsync(m => m.LatestProId == id);
            if (lastestPro == null)
            {
                return NotFound();
            }

            return View(lastestPro);
        }

        // GET: Administrator/LastestProes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/LastestProes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LatestProId,LatestProImg,LatestProTilte,Rate,Like,price")] LastestProViewModel model  )
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (model.LatestProImg != null)
                {


                    string UploadFplder = Path.Combine(webHostEnvironment.WebRootPath, "RecentImg");
                    fileName = Guid.NewGuid().ToString() + "_" + model.LatestProImg.FileName;
                    string filepath = Path.Combine(UploadFplder, fileName);
                    model.LatestProImg.CopyTo(new FileStream(filepath, FileMode.Create));
                }


                var lastest = new LastestPro()
                {
                    LatestProTilte = model.LatestProTilte,
                    Like = model.Like,
                    price = model.price,
                    Rate  = model.Rate,

                    LatestProImg = fileName
                };
                _context.lastestPros.Add(lastest);
               await _context.SaveChangesAsync();
                return RedirectToAction("Index", "LastestProes");
            }
            return View();
        
    }

        // GET: Administrator/LastestProes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lastestPro = await _context.lastestPros.FindAsync(id);
            if (lastestPro == null)
            {
                return NotFound();
            }
            return View(lastestPro);
        }

        // POST: Administrator/LastestProes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LatestProId,LatestProImg,LatestProTilte,Rate,Like,price")] LastestPro lastestPro)
        {
            if (id != lastestPro.LatestProId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lastestPro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LastestProExists(lastestPro.LatestProId))
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
            return View(lastestPro);
        }

        // GET: Administrator/LastestProes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lastestPro = await _context.lastestPros
                .FirstOrDefaultAsync(m => m.LatestProId == id);
            if (lastestPro == null)
            {
                return NotFound();
            }

            return View(lastestPro);
        }

        // POST: Administrator/LastestProes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lastestPro = await _context.lastestPros.FindAsync(id);
            _context.lastestPros.Remove(lastestPro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LastestProExists(int id)
        {
            return _context.lastestPros.Any(e => e.LatestProId == id);
        }
    }
}
