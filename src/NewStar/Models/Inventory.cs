using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewStar.Models
{
    public class Inventory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Used { get; set; }
        public int Available { get; set; }

        public int ID { get; internal set; }
    }
}
