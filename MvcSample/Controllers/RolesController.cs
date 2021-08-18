using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class RolesController : Controller
    {
        //
        // GET: /Roles/

        public ActionResult Index()
        {
            RolesEBL rolesEBL = new RolesEBL();

            List<Roles> Roles = rolesEBL.Roless.ToList();
            return View(Roles);
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
                RolesEBL rolesEBL = new RolesEBL();

               Roles roles = new Roles();
                UpdateModel<Roles>(roles);
                rolesEBL.AddRoles(roles);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            RolesEBL rolesEBL = new RolesEBL();

            Roles roles = rolesEBL.Roless.Single(emp => emp.ID == id);
            return View(roles);
        }

        [HttpPost]
        public ActionResult Edit(Roles roles)
        {
            if (ModelState.IsValid)
            {
                RolesEBL rolesEBL =
                new RolesEBL(); rolesEBL.SaveRoles(roles);
                ViewBag.Message = ("Edited Successfully");
                //return RedirectToAction("Index");
            }
            return View(roles);
        }

        public ActionResult Delete(int id)
        {
            RolesEBL rolesEBL =
            new RolesEBL();
            rolesEBL.DeleteRoles(id);
            return RedirectToAction("Index");
        }


    }
}
