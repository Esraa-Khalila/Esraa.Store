using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Models
{
    public class Featured
    {
        [Key]
        public int FeaturedId { get; set; }
   
        public string featuredImg { get; set; }
    
   
        public string featuredTilte { get; set; }
        public int Rate { get; set; }
        public int Like { get; set; }
        public decimal price { get; set; }
        public int que { get; set; }
        public decimal Total { get; set; }
    }
}
