using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class FoodController : Controller
    {
        //
        // GET: /Food/

        public ActionResult Index()
        {
            FoodEBL foodEBL = new FoodEBL();

            List<Food> food = foodEBL.Foods.ToList();
            return View(food);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                FoodEBL foodEBL =
                new FoodEBL();
                Food food = new Food();
                UpdateModel<Food>(food);
                foodEBL.AddFood(food);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            FoodEBL foodEBL = new FoodEBL();

            Food food = foodEBL.Foods.Single(emp => emp.ID == id);
            return View(food);
        }

        [HttpPost]
        public ActionResult Edit(Food food)
        {
            if (ModelState.IsValid)
            {
                FoodEBL foodEBL =
                new FoodEBL(); foodEBL.SaveFood(food);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(food);
        }

        public ActionResult Delete(int id)
        {
            FoodEBL foodEBL =
            new FoodEBL();
            foodEBL.DeleteFood(id);
            return RedirectToAction("Index");
        }

    }
}
