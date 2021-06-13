using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Esraa_Store.Data;
using Esraa_Store.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Esraa_Store.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Esraa_Store.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class FeaturedsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public FeaturedsController(ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        // GET: Administrator/Featureds
        public async Task<IActionResult> Index(Featured featured)
        {
           
            var obj = (await _context.featureds.ToListAsync());
            
            return View(obj);
        }

        // GET: Administrator/Featureds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featured = await _context.featureds
                .FirstOrDefaultAsync(m => m.FeaturedId == id);
            if (featured == null)
            {
                return NotFound();
            }

            return View(featured);
        }

        // GET: Administrator/Featureds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Featureds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeaturedId,featuredImg,featuredTilte,Rate,Like,price")] FeaturedViewModel model)
       {
            if (ModelState.IsValid)
            {

                    string fileName = null;
                    if (model.featuredImg != null)
                    {


                        string UploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "FeaturedImg");
                        fileName = Guid.NewGuid().ToString() + "_" + model.featuredImg.FileName;
                        string filepath = Path.Combine(UploadFolder, fileName);
                        model.featuredImg.CopyTo(new FileStream(filepath, FileMode.Create));
                    }

                var featured = new Featured()
                {
                    featuredTilte = model.featuredTilte,
                    Like = model.Like = 0,
                    price = model.price,
                    Rate =model.Rate,
                   
                    featuredImg = fileName
                };
                _context.Add(featured);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }  
            return View();
        }

        // GET: Administrator/Featureds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featured = await _context.featureds.FindAsync(id);
            if (featured == null)
            {
                return NotFound();
            }
            return View(featured);
        }

        
        // POST: Administrator/Featureds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeaturedId,featuredImg,featuredTilte,Rate,Like,price")] Featured featured)
        {
            if (id != featured.FeaturedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featured);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturedExists(featured.FeaturedId))
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
            return View(featured);
        }

        // GET: Administrator/Featureds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featured = await _context.featureds
                .FirstOrDefaultAsync(m => m.FeaturedId == id);
            if (featured == null)
            {
                return NotFound();
            }

            return View(featured);
        }

        // POST: Administrator/Featureds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var featured = await _context.featureds.FindAsync(id);
            _context.featureds.Remove(featured);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturedExists(int id)
        {
            return _context.featureds.Any(e => e.FeaturedId == id);
        }
    }
}
