using System;
using System.Collections.Generic;
using NewStar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NewStar.ViewModels
{
    public class AddListItemViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide the number of items")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }
    }
}
