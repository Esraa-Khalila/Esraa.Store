using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Models.ViewModels
{
    public class LastestProViewModel
    {
        [Key]
        public int LatestProId { get; set; }
   
        public IFormFile LatestProImg { get; set; }

        
        public string LatestProTilte { get; set; }
        public int Rate { get; set; }
        public int Like { get; set; }
        public decimal price { get; set; }

  
    }
}
