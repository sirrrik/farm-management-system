using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class TreatmentController : Controller
    {
        //
        // GET: /Treatment/

        public ActionResult Index()
        {
            TreatmentEBL treatmentEBL = new TreatmentEBL();

            List<Treatment> treatment = treatmentEBL.Treatments.ToList();
            return View(treatment);
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
                TreatmentEBL treatmentEBL = new TreatmentEBL();
               
                Treatment treatment = new Treatment();
                UpdateModel<Treatment>(treatment);
                treatmentEBL.AddTreatment(treatment);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            TreatmentEBL treatmentEBL = new TreatmentEBL();

            Treatment treatment = treatmentEBL.Treatments.Single(emp => emp.ID == id);
            return View(treatment);
        }

        [HttpPost]
        public ActionResult Edit(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                TreatmentEBL treatmentEBL =
                new TreatmentEBL(); treatmentEBL.SaveTreatment(treatment);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(treatment);
        }

        public ActionResult Delete(int id)
        {
            TreatmentEBL treatmentEBL =
            new TreatmentEBL();
            treatmentEBL.DeleteTreatment(id);
            return RedirectToAction("Index");
        }

    }
}
