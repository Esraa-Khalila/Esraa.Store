using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esraa_Store.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string TitleJob { get; set; }
        public DateTime dateTime { get; set; }
        public string Image { get; set; }
    }
}
