using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Models.ViewModels
{
    public class ExclusiveViewModel
    {
        public int ExclusiveId { get; set; }
        public IFormFile exclusiveImg { get; set; }
        public string exclusiveTilte { get; set; }

        public string exclusiveDec { get; set; }
    }
}
