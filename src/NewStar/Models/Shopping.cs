using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewStar.Models
{
    public class Shopping
    {
        public int ShoppingID { get; set; }
        public string Name { get; set; }

        public int InventoryID { get; set; }
        public Inventory Inventory { get; set; }
    }
}
