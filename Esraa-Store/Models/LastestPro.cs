using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Models
{
    public class LastestPro
    {
        [Key]
        public int LatestProId { get; set; }
        public string LatestProImg { get; set; }
        
    
        public string LatestProTilte { get; set; }
        public int Rate { get; set; }
        public int Like { get; set; }
        public decimal price { get; set; }
    }
}

