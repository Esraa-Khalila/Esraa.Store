using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Esraa_Store.Data;
using Esraa_Store.Models;
using Esraa_Store.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Esraa_Store.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class ExclusivesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ExclusivesController(ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        // GET: Administrator/Exclusives
        public async Task<IActionResult> Index()
        {
            return View(await _context.exclusives.ToListAsync());
        }

        // GET: Administrator/Exclusives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exclusive = await _context.exclusives
                .FirstOrDefaultAsync(m => m.ExclusiveId == id);
            if (exclusive == null)
            {
                return NotFound();
            }

            return View(exclusive);
        }

        // GET: Administrator/Exclusives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Exclusives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExclusiveId,exclusiveImg,exclusiveTilte,exclusiveDec")] ExclusiveViewModel model)
        {
            if (ModelState.IsValid)
            {
                string file = null;
                if (model.exclusiveImg!=null)
                {
                    string Upload = Path.Combine(webHostEnvironment.WebRootPath, "ExclusiveImg");
                    file = Guid.NewGuid().ToString() + "_" + model.exclusiveImg.FileName;
                    string Img = Path.Combine(Upload, file);
                    model.exclusiveImg.CopyTo(new FileStream(Img, FileMode.Create));
                }
                var Exc = new Exclusive()
                {
                    exclusiveDec = model.exclusiveDec,
                    exclusiveTilte = model.exclusiveTilte,
                    exclusiveImg = file
                };
                _context.Add(Exc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Administrator/Exclusives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exclusive = await _context.exclusives.FindAsync(id);
            if (exclusive == null)
            {
                return NotFound();
            }
            return View(exclusive);
        }

        // POST: Administrator/Exclusives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExclusiveId,exclusiveImg,exclusiveTilte,exclusiveDec")] Exclusive exclusive)
        {
            if (id != exclusive.ExclusiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exclusive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExclusiveExists(exclusive.ExclusiveId))
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
            return View(exclusive);
        }

        // GET: Administrator/Exclusives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exclusive = await _context.exclusives
                .FirstOrDefaultAsync(m => m.ExclusiveId == id);
            if (exclusive == null)
            {
                return NotFound();
            }

            return View(exclusive);
        }

        // POST: Administrator/Exclusives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exclusive = await _context.exclusives.FindAsync(id);
            _context.exclusives.Remove(exclusive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExclusiveExists(int id)
        {
            return _context.exclusives.Any(e => e.ExclusiveId == id);
        }
    }
}
