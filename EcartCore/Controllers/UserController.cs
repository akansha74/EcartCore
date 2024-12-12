using EcartCore.Data;
using EcartCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcartCore.Controllers
{
    public class UserController : Controller
    {

        MyDbContext context = new MyDbContext();
        public IActionResult Index()
        {
         
            ViewBag.UserList = context.AppUser.ToList();
            return View(ViewBag.UserList);
        }
        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            AppUser model = new AppUser();
            if (id > 0)
            {
                model = context.AppUser.Find(id);
            }
            //dropdown
            var list = new SelectList(context.City.ToList(), "CityId", "CityName");
            // ViewBag.citylist = list;
            model.citylist = list;
            //radiobutton
            var list2 = new SelectList(context.Gender.ToList(), "GenderId", "GenderName");

            model.genderlist = list2;
            //checkbox
            List<SelectListItem> list3 = new List<SelectListItem>();

            var interestlist = context.Interest.ToList();
            foreach (var item in interestlist)
            {
                SelectListItem element = new SelectListItem();
                element.Text=item.Name;
                element.Value = item.InterestId.ToString();
                list3.Add(element);
            }
            model.interestlist = list3;
                return View(model);
        }
        [HttpPost]
        public IActionResult CreateOrEdit(AppUser model)
        {
            if (ModelState.IsValid)

            {
                model.interestlist=model.interestlist.Where(x=>x.Selected==true).ToList();

                if (model.UserId > 0)
                {
                    context.AppUser.Update(model);
                    context.SaveChanges();
                }
                else
                {
                    context.AppUser.Add(model);
                    context.SaveChanges();
                    List<UserInterest> userinterestlist = new List<UserInterest>();
                    foreach (var item in model.interestlist)
                    {
                        userinterestlist.Add(new UserInterest() { UserId = model.UserId, InterestId = Convert.ToInt32(item.Value) });
                    }
                    context.UserInterest.AddRange(userinterestlist);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
