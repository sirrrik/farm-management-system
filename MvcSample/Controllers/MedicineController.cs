using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class MedicineController : Controller
    {
        //
        // GET: /Medicine/

        public ActionResult Index()
        {
            MedicineEBL medicineEBL = new MedicineEBL();

            List<Medicine> medicine = medicineEBL.Medicines.ToList();
            return View(medicine);
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
                MedicineEBL medicineEBL =
                new MedicineEBL();
                Medicine medicine = new Medicine();
                UpdateModel<Medicine>(medicine);
                medicineEBL.AddMedicine(medicine);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            MedicineEBL medicineEBL = new MedicineEBL();

            Medicine medicine = medicineEBL.Medicines.Single(emp => emp.ID == id);
            return View(medicine);
        }

        [HttpPost]
        public ActionResult Edit(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                MedicineEBL medicineEBL =
                new MedicineEBL(); medicineEBL.SaveMedicine(medicine);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(medicine);
        }

        public ActionResult Delete(int id)
        {
            MedicineEBL medicineEBL =
            new MedicineEBL();
            medicineEBL.DeleteCalves(id);
            return RedirectToAction("Index");
        }

    }
}
