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
            IList<Shopping> ShoppingLists = context.ShoppingLists.ToList();
            return View(ShoppingLists);
        }

        public IActionResult AddList()
        {
            AddListViewModel addListViewModel = new AddListViewModel();
            return View(addListViewModel);
        }

        [HttpPost]
        public IActionResult AddList(AddListViewModel addListViewModel)
        {
            if (ModelState.IsValid)
            {
                Shopping newList = new Shopping
                {
                    Name = addListViewModel.Name,
                };

                context.ShoppingLists.Add(newList);
                context.SaveChanges();
            }

            return Redirect("/Inventory/Shopping");
        }

        public IActionResult ViewList(int ID)
        {
            IList<ShoppingList> ListItems = context.ShoppingList.ToList();
            return View(ListItems);
        }

        public IActionResult AddItem()
        {
            AddListItemViewModel addListItemViewModel = new AddListItemViewModel();
            return View(addListItemViewModel);
        }

        [HttpPost]
        public IActionResult AddItem(AddListItemViewModel addListItemViewModel)
        {
            if (ModelState.IsValid)
            {
                ShoppingList newListItem = new ShoppingList
                {
                    Item = addListItemViewModel.Name,
                };

                context.ShoppingList.Add(newListItem);
                context.SaveChanges();
            }

            return Redirect("/Inventory/Shopping/");
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

        public IActionResult RemoveList(int ID)
        {
            var slist = (from a in context.ShoppingLists
                             where a.ID == ID
                             select a).FirstOrDefault();

            context.ShoppingLists.Remove(slist);
            context.SaveChanges();
            return Redirect("/Inventory/Shopping");
        }

    }
}
