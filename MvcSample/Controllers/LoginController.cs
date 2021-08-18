using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcSample.Models;

namespace MvcSample.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(MvcSample.Models.User userModel)
        {
            using (schoolEntities1 db = new schoolEntities1())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "wrong username or passowrd";
                    return View("Userlogin", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["userName"] = userDetails.UserName;
                    return RedirectToAction("Index", "CowProfile");
                }
            }

        }
        public ActionResult Logout()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("UserLogin", "Login");
        }


    }
}
