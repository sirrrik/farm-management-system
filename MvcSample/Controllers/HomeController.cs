using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSample.Models;
using System.IO;



namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {   
            return View();
        }
        public ActionResult showUserList()
        {
            MvcSample.Models.schoolEntities1 db = new MvcSample.Models.schoolEntities1();
            var c = (from b in db.Users select b).ToList();
            return View();
            
        }

    }
}
