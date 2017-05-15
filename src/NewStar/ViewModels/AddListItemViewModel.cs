using System;
using System.Collections.Generic;
using NewStar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NewStar.ViewModels
{
    public class AddListItemViewModel
    {
        public Shopping ShoppingList { get; set; }
        public List<SelectListItem> Items { get; set; }

        public int ShoppingListID { get; set; }
        public int ID { get; set; }

    }
}
