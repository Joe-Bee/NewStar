using NewStar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewStar.ViewModels
{
    public class AddInventoryViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give a description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must provide the number of items")]
        [Display(Name = "# of Items")]
        public int Available { get; set; }
    }
}
