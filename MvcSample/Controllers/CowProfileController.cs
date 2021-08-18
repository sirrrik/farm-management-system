using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class CowProfileController : Controller
    {
        public ActionResult Index()
        {
            CowProfileEBLf cowProfileEBLf = new CowProfileEBLf();

            List<CPemp> cPemps = cowProfileEBLf.Cowprofiles.ToList();
            return View(cPemps);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CowProfileEBLf cowProfileEBLf = new CowProfileEBLf();

            CPemp cPemp = cowProfileEBLf.Cowprofiles.Single(emp => emp.ID == id);
            return View(cPemp);
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            CPemp cPemp = new CPemp();
            // Retrieve form data using form collection
            cPemp.Age = formCollection["Age"];
            cPemp.Breed = formCollection["Breed"];
            cPemp.Health = formCollection["Health"];
            cPemp.DateOfBirth =
            Convert.ToDateTime(formCollection["DateOfBirth"]);
            CowProfileEBLf cowProfileEBLf = new CowProfileEBLf();
            cowProfileEBLf.AddCPemp(cPemp);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(CPemp cPemp)
        {
            if (ModelState.IsValid)
            {
                CowProfileEBLf cowProfileEBLf =
                new CowProfileEBLf(); cowProfileEBLf.SaveCPemp(cPemp);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(cPemp);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            CowProfileEBLf cowProfileEBLf =
            new CowProfileEBLf();
            cowProfileEBLf.DeleteCPemp(id); 
            return RedirectToAction("Index");
        }


    }

}
