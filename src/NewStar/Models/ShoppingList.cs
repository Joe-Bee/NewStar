using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewStar.Models
{
    public class ShoppingList
    {
        public int ID { get; set; }
        public int ListID { get; set; }

        public string Item { get; set; }
        public int Amount { get; set; }
    }
}
