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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Esraa_Store.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TeamsController(ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        // GET: Administrator/Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

        // GET: Administrator/Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Administrator/Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,Name,TitleJob,dateTime,Image")] TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                string file = null;
                if (model.Image!=null)
                {
                    string upload = Path.Combine(webHostEnvironment.WebRootPath,"TeamImg");
                    file = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string Img = Path.Combine(upload, file);
                    model.Image.CopyTo(new FileStream(Img, FileMode.Create));

                }
                var Team = new Team
                {
                    TitleJob = model.TitleJob,
                    dateTime = model.dateTime,
                    Name = model.Name,
                    Image = file
                };
                _context.Add(Team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Administrator/Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Administrator/Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,Name,TitleJob,dateTime,Image")] Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
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
            return View(team);
        }

        // GET: Administrator/Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Administrator/Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}
