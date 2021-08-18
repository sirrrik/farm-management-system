using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class CalvesController : Controller
    {
        //
        // GET: /Calves/

        public ActionResult Index()
        {
            CalvesEBL calvesEBL = new CalvesEBL();

            List<Calves> calves = calvesEBL.Calvess.ToList();
            return View(calves);
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
                CalvesEBL calvesEBL =
                new CalvesEBL();
                Calves calves = new Calves();
                UpdateModel<Calves>(calves);
                calvesEBL.AddCalves(calves);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            CalvesEBL calvesEBL = new CalvesEBL();

            Calves calves = calvesEBL.Calvess.Single(emp => emp.ID == id);
            return View(calves);
        }

        [HttpPost]
        public ActionResult Edit(Calves calves)
        {
            if (ModelState.IsValid)
            {
                CalvesEBL calvesEBL =
                new CalvesEBL(); calvesEBL.SaveCalves(calves);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(calves);
        }

        public ActionResult Delete(int id)
        {
            CalvesEBL calvesEBL =
            new CalvesEBL();
            calvesEBL.DeleteCalves(id);
            return RedirectToAction("Index");
        }


    }
}
