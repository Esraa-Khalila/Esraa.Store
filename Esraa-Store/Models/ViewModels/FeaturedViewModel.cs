using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Models.ViewModels
{
    public class FeaturedViewModel
    {
        public int FeaturedId { get; set; }

       

        public IFormFile featuredImg { get; set; }
        public string featuredTilte { get; set; }
        public int Rate { get; set; }
        public int Like { get; set; }
        public decimal price { get; set; }
        public int que { get; set; }
        public decimal Total { get; set; }
        public List<Featured> MyProperty { get; set; }
    }
}
