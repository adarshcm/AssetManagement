using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Models;
using AssetManagement.DAL;

namespace AssetManagement.Controllers
{
    public class LoginRegController : Controller
    {
        // GET: LoginReg
        public ActionResult OpenLogin()
        {
            ViewBag.login = "Login";
            return View();
        }


        public ActionResult LoginCheck(CustomLoginRegViewModel model)
        {
            try
            {
                LoginRegDAL lr = new LoginRegDAL();
                bool status = lr.loginCheck(model.Email,model.Password);
                
                if (status)
                {
                    ViewBag.login = "Logout";
                    ViewBag.isAdmin = "admin";
                    Session["isAdmin"] = "admin";
                    return View("~/Views/LoginReg/OpenAccountPage.cshtml");
                }
                else
                {
                    ViewBag.message = "The email and password you entered don't match.";
                    return View("~/Views/LoginReg/OpenLogin.cshtml");
                }
            }
            catch (Exception exc)
            {
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            ViewBag.login = "Login";
            Session["isAdmin"] = null;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}