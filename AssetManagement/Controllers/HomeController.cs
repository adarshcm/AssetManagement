using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Models;
using Newtonsoft.Json.Linq;
using AssetManagement.DAL;

namespace AssetManagement.Controllers
{
    public class HomeController : Controller
    {
        AssetDetailsDAL assetDetailsDal = new AssetDetailsDAL();
        public ActionResult Index()
        {
            ViewBag.login = "Login";
            JArray jarr = getMarkers();
            ViewBag.getMarkers = jarr;
            return View();
        }

        public JArray getMarkers()
        {
            JArray jarray = new JArray();

            JArray jarr = new JArray();
            jarr.Add(76.696781);
            jarr.Add(12.419746);
            JObject jobj = new JObject();
            jobj.Add("co_ordinates",jarr);
            jobj.Add("name", "Daria Daulat Bagh");
            jobj.Add("color", "#CC3333");
            jarray.Add(jobj);


            jarr = new JArray();
            jarr.Add(76.679210);
            jarr.Add(12.425049);
            jobj = new JObject();
            jobj.Add("co_ordinates", jarr);
            jobj.Add("name", "Gol Gumbaz");
            jobj.Add("color", "blue");

            jarray.Add(jobj);

            return jarray;
        }


        public ActionResult About(string assetType)
        {
            
            //AssetViewModels model = new AssetViewModels();
            //model.assetTypeFlow = assetType;
            //ViewBag.assetTypeFlow = assetType;
            //model.populateAssetViewModel();
            return View("~/Views/Home/About.cshtml");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OpenInstituion()
        {

            return View();
        }

        public ActionResult ViewInstituionDetails()
        {
            AssetViewModels model = new AssetViewModels();
            ViewBag.assetFlow = "EditAsset";
            model.populateAssetViewModel();

            model = assetDetailsDal.getAssetDetailsForEditFLow("KAMANSHR001MI", model);
            return View(model);
        }

        public ActionResult OpenReport()
        {

            return View();
        }
    }
}