using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewStar.Data;
using NewStar.ViewModels;
using NewStar.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NewStar.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext context;
        public InventoryController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()  //Maybe Change back to Index
        {
            IList<Inventory> Items = context.Items.ToList();

            return View(Items);
        }

        public IActionResult Add()
        {
            AddInventoryViewModel addInventoryViewModel = new AddInventoryViewModel();
            return View(addInventoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddInventoryViewModel addInventoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Inventory newItem = new Inventory
                {
                    Name = addInventoryViewModel.Name,
                    Description = addInventoryViewModel.Description,
                };

                context.Items.Add(newItem);
                context.SaveChanges();
            }

                return Redirect("/Inventory");
        }

        public IActionResult Update()
        {

        }

        [HttpPost]
        public IActionResult Update()
        {

        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Inventory";
            ViewBag.items = context.Items.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult Remove(int[] itemIds)
        {
            foreach (int itemId in itemIds)
            {
                Inventory theItem = context.Items.Single(c => c.ID == itemId);
                context.Items.Remove(theItem);
            }

            context.SaveChanges();

            return Redirect("/Inventory");
        }
    }
}
