using EcartCore.Data;
using EcartCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EcartCore.Controllers
{
    public class ProductController : Controller
    {
        MyDbContext context = new MyDbContext();
        public IActionResult Index()
        {
            List<Product> model = context.Product.ToList();
            return View(model);
            
        }
        public IActionResult Create()
        {
            ViewBag.CategoryList = context.Product.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                context.Product.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }
        public IActionResult Edit(int id)
        {

            var obj = context.Product.Find(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            context.Product.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Details(Product model)
        {
            return View();
        }
    }
}
