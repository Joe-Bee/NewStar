using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewStar.Models
{
    public class Shopping
    {
        public int ID { get; set; }
        public string ShoppingList { get; set; }

        public int InventoryID { get; set; }
        public Inventory Inventory { get; set; }
    }
}
