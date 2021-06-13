using Esraa_Store.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Models.ViewComponents
{
    public class TeamViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext db;

        public TeamViewComponent(ApplicationDbContext _db)
        {
            db = _db;   
        }
      
        public IViewComponentResult Invoke()
        {
            return View(db.Teams.ToList());
        }
    }
}
