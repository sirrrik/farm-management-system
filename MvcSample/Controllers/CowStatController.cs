using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class CowStatController : Controller
    {
        //
        // GET: /CowStat/

        public ActionResult Index()
        {
            CowstatusBusinessLayer cowstatusBusinessLayer = new CowstatusBusinessLayer();

            List<Cowstatusemp> cowstatusemp = cowstatusBusinessLayer.Cowstatusemps.ToList();
            return View(cowstatusemp);
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
                CowstatusBusinessLayer cowstatusBusinessLayer =
                new CowstatusBusinessLayer();
                Cowstatusemp cowstatusemp = new Cowstatusemp();
                UpdateModel<Cowstatusemp>(cowstatusemp);
                cowstatusBusinessLayer.AddCowstatusemp(cowstatusemp);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            CowstatusBusinessLayer cowstatusBusinessLayer = new CowstatusBusinessLayer();

            Cowstatusemp cowstatusemp = cowstatusBusinessLayer.Cowstatusemps.Single(emp => emp.ID == id);
            return View(cowstatusemp);
        }

        [HttpPost]
        public ActionResult Edit(Cowstatusemp cowstatusemp)
        {
            if (ModelState.IsValid)
            {
                CowstatusBusinessLayer cowstatusBusinessLayer =
                new CowstatusBusinessLayer(); cowstatusBusinessLayer.SaveCowstatusemp(cowstatusemp);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(cowstatusemp);
        }

        public ActionResult Delete(int id)
        {
            CowstatusBusinessLayer cowstatusBusinessLayer =
            new CowstatusBusinessLayer();
            cowstatusBusinessLayer.DeleteCowstatusemp(id);
            return RedirectToAction("Index");
        }

    }
}
