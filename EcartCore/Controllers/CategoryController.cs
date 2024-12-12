using EcartCore.Data;
using EcartCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EcartCore.Controllers
{
    public class CategoryController : Controller
    {
        MyDbContext context = new MyDbContext();
        public IActionResult Index()
        {
           ViewBag.CategoryList=context.Category.ToList();
            return View(ViewBag.CategoryList);
        }
        public IActionResult Create()
        {
            Category model = new Category();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                context.Category.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
          else
            {
                return View();
            }
           

          
        }
        public IActionResult Edit( int id)
        {

          var obj=  context.Category.Find(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            context.Category.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Details(Category model)
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCategoryDropdown()

        {
            var dropdownlist = context.Category.ToList();
            return Json(dropdownlist);
        }
        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            Category model = new Category();
            if(id>0)
            {
                 model = context.Category.Find(id);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateOrEdit(Category model)
        {
            if (ModelState.IsValid)
            {
                if (model.CategoryId > 0)
                {
                    context.Category.Update(model);
                    context.SaveChanges();
                }
                else
                {
                    context.Category.Add(model);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
           
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int CategoryId)
        {
            var obj = context.Category.Find(CategoryId);

            if (obj != null)
                {
                    context.Category.Remove(obj);
                    context.SaveChanges();
                    return Json(obj);
                }
          

            return new EmptyResult();
        }
    }
}
