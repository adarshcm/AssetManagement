using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string assetType)
        {
            AssetViewModels model = new AssetViewModels();
            model.assetTypeFlow = assetType;
            ViewBag.assetTypeFlow = assetType;
            model.populateAssetViewModel();
            return View("~/Views/Home/About.cshtml",model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}