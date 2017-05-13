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

        [HttpPost]
        public IActionResult Index(Dictionary<string,string> a)
        {
            return null;
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
                    Available = addInventoryViewModel.Available
                };

                context.Items.Add(newItem);
                context.SaveChanges();
            }

                return Redirect("/Inventory");
        }

        public IActionResult Update(int ID)
        {
            var inventory = (from a in context.Items
                             where a.ID == ID
                             select a).FirstOrDefault();

            if (HttpContext.Request.Method == "POST")
            {
                {
                    int a;
                    int.TryParse(Request.Form["Available"], out a);
                    if (a >= 0)
                    {
                        inventory.Name = Request.Form["Name"];
                        inventory.Description = Request.Form["Description"];
                        inventory.Available = a;
                        context.Items.Update(inventory);
                        context.SaveChanges();
                        Response.Redirect("/Inventory/Index");
                    }
                };
            }

            return View(inventory);
        }

        public IActionResult Shopping()
        {
            return View();
        }

        public IActionResult Remove(int ID)
        {
            var inventory = (from a in context.Items
                             where a.ID == ID
                             select a).FirstOrDefault();

            context.Items.Remove(inventory);
            context.SaveChanges();
            return Redirect("/Inventory");
        }
        
    }
}
