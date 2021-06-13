using Esraa_Store.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base (options)
        {
                
        }

        public DbSet <Exclusive> exclusives{ get; set; }
        public DbSet<Featured> featureds { get; set; }
        public DbSet<LastestPro> lastestPros { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet <Contact> contacts { get; set; }
    }
}
