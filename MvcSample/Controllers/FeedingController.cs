using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class FeedingController : Controller
    {
        //
        // GET: /Feeding/

        public ActionResult Index()
        {
            FeedingEBL feedingEBL = new FeedingEBL();

            List<Feeding> feeding = feedingEBL.Feedings.ToList();
            return View(feeding);
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
                FeedingEBL feedingEBL =
                new FeedingEBL();
                Feeding feeding = new Feeding();
                UpdateModel<Feeding>(feeding);
                feedingEBL.AddFeeding(feeding);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            FeedingEBL feedingEBL = new FeedingEBL();

            Feeding feeding = feedingEBL.Feedings.Single(emp => emp.ID == id);
            return View(feeding);
        }

        [HttpPost]
        public ActionResult Edit(Feeding feeding)
        {
            if (ModelState.IsValid)
            {
                FeedingEBL feedingEBL =
                new FeedingEBL(); feedingEBL.SaveFeeding(feeding);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(feeding);
        }

        public ActionResult Delete(int id)
        {
            FeedingEBL feedingEBL =
            new FeedingEBL();
            feedingEBL.DeleteFeeding(id);
            return RedirectToAction("Index");
        }


    }
}
