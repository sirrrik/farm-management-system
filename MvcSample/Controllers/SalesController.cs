using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class SalesController : Controller
    {
        //
        // GET: /Sales/

        public ActionResult Index()
        {
            SalesEBL salesEBL = new SalesEBL();

            List<Sales> Milk = salesEBL.Saless.ToList();
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
                SalesEBL salesEBL = new SalesEBL();

                Sales sales = new Sales();
                UpdateModel<Sales>(sales);
                salesEBL.AddSales(sales);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            SalesEBL salesEBL = new SalesEBL();

           Sales sales = salesEBL.Saless.Single(emp => emp.ID == id);
            return View(sales);
        }

        [HttpPost]
        public ActionResult Edit(Sales sales)
        {
            if (ModelState.IsValid)
            {
                SalesEBL salesEBL =
                new SalesEBL(); salesEBL.SaveSales(sales);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(sales);
        }

        public ActionResult Delete(int id)
        {
            SalesEBL salesEBL =
            new SalesEBL();
            salesEBL.DeleteSales(id);
            return RedirectToAction("Index");
        }

    }
}
