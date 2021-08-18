using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class MilkController : Controller
    {
        //
        // GET: /Milk/
        public ActionResult Index()
        {
            MilkEBL milkEBL = new MilkEBL();

            List<Milk> Milk = milkEBL.Milks.ToList();
            return View(Milk);
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
                MilkEBL milkEBL = new MilkEBL();
               
                Milk milk = new Milk();
                UpdateModel<Milk>(milk);
                milkEBL.AddMilk(milk);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            MilkEBL milkEBL = new MilkEBL();

            Milk milk = milkEBL.Milks.Single(emp => emp.ID == id);
            return View(milk);
        }

        [HttpPost]
        public ActionResult Edit(Milk milk)
        {
            if (ModelState.IsValid)
            {
                MilkEBL milkEBL =
                new MilkEBL(); milkEBL.SaveCowstatusemp(milk);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(milk);
        }

        public ActionResult Delete(int id)
        {
            MilkEBL milkEBL =
            new MilkEBL();
            milkEBL.DeleteCowstatusemp(id);
            return RedirectToAction("Index");
        }

       

    }
}
