using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Models;
using Newtonsoft.Json.Linq;
using AssetManagement.DAL;
using System.IO;
using System.Globalization;

namespace AssetManagement.Controllers
{
    public class HomeController : Controller
    {
        AssetDetailsDAL assetDetailsDal = new AssetDetailsDAL();

        public ActionResult Index()
        {
            JArray jarr = getMarkers();
            ViewBag.getMarkers = jarr;
            return View();
        }

        public JArray getMarkers(string institutionId = null, string institutionName = null)
        {
            JArray jarray = assetDetailsDal.getMarkersFromDB();
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

        public ActionResult ViewInstituionDetails(string InstitutionId)
        {
            AssetViewModels model = new AssetViewModels();
            ViewBag.assetFlow = "EditAsset";
            model.populateAssetViewModel();

            model = assetDetailsDal.getAssetDetailsForEditFLow(InstitutionId, model);
            List<ImageDetails> lstMan = new List<ImageDetails>();
            foreach(var i in model.managementDetails)
            {
                lstMan.Add(i.image);
            }
            createDirAndImage(lstMan);

            List<ImageDetails> lstAdv = new List<ImageDetails>();
            foreach (var i in model.advisoryDetails)
            {
                lstAdv.Add(i.image);
            }
            createDirAndImage(lstAdv);

            if (model.managementDetails != null)
            {
                JArray jarray = new JArray();
                foreach (var i in model.managementDetails)
                {
                    JObject jobj = new JObject();
                    jobj.Add("Designation", i.designation);
                    jobj.Add("Name", i.name);
                    jobj.Add("Mobile No", i.mobile);
                    jobj.Add("E-mail Id", i.emailID);
                    //jobj.Add("Appointment Date", i.appointmentDate);
                    jobj.Add("Image", i.imageName);

                    jarray.Add(jobj);
                    
                }

                ViewBag.managementDetailsList = jarray;
            }

            if (model.advisoryDetails != null)
            {
                JArray jarray = new JArray();
                foreach (var i in model.advisoryDetails)
                {
                    JObject jobj = new JObject();
                    jobj.Add("Designation", i.designation);
                    jobj.Add("Name", i.name);
                    jobj.Add("Mobile No", i.mobile);
                    jobj.Add("E-mail Id", i.emailID);
                    //jobj.Add("Appointment Date", i.appointmentDate);
                    jobj.Add("Image", i.imageName);

                    jarray.Add(jobj);

                }

                ViewBag.advisoryDetailsList = jarray;
            }

            List<string> assetStatusImageLst = new List<string>();
            foreach (var i in model.assetStatusImages)
            {
                assetStatusImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.assetStatusImages);
            ViewBag.assetStatusImage = assetStatusImageLst;

            List<string> gnNumberImageLst = new List<string>();
            foreach (var i in model.gnNumberImages)
            {
                gnNumberImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.gnNumberImages);
            ViewBag.gnNumberImage = gnNumberImageLst;

            List<string> crNumberImageLst = new List<string>();
            foreach (var i in model.crNumberImages)
            {
                crNumberImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.crNumberImages);
            ViewBag.crNumberImage = crNumberImageLst;

            List<string> courtOrderImageLst = new List<string>();
            foreach (var i in model.courtOrderImages)
            {
                courtOrderImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.courtOrderImages);
            ViewBag.courtOrderImage = courtOrderImageLst;

            List<string> surveyNoImageLst = new List<string>();
            foreach (var i in model.surveyNoImages)
            {
                surveyNoImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.surveyNoImages);
            ViewBag.surveyNoImage = surveyNoImageLst;

            List<string> khathaNoImageLst = new List<string>();
            foreach (var i in model.khathaNoImages)
            {
                khathaNoImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.khathaNoImages);
            ViewBag.khathaNoImage = khathaNoImageLst;

            List<string> municipalNoImageLst = new List<string>();
            foreach (var i in model.municipalNoImages)
            {
                municipalNoImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.municipalNoImages);
            ViewBag.municipalNoImage = municipalNoImageLst;

            List<string> northImageLst = new List<string>();
            foreach (var i in model.northImages)
            {
                northImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.northImages);
            ViewBag.northImage = northImageLst;

            List<string> eastImageLst = new List<string>();
            foreach (var i in model.eastImages)
            {
                eastImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.eastImages);
            ViewBag.eastImage = eastImageLst;

            List<string> southImageLst = new List<string>();
            foreach (var i in model.southImages)
            {
                southImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.southImages);
            ViewBag.southImage = southImageLst;

            List<string> westImageLst = new List<string>();
            foreach (var i in model.westImages)
            {
                westImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.westImages);
            ViewBag.westImage = westImageLst;

            List<string> estimatedValueImageLst = new List<string>();
            foreach (var i in model.estimatedValueImages)
            {
                estimatedValueImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.estimatedValueImages);
            ViewBag.estimatedValueImage = estimatedValueImageLst;

            List<string> litigationManagementImageLst = new List<string>();
            foreach (var i in model.litigationManagementImages)
            {
                litigationManagementImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.litigationManagementImages);
            ViewBag.litigationManagementImage = litigationManagementImageLst;

            List<string> litigationAssetImageLst = new List<string>();
            foreach (var i in model.litigationAssetImages)
            {
                litigationAssetImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.litigationAssetImages);
            ViewBag.litigationAssetImage = litigationAssetImageLst;

            List<string> geoStampedImageLst = new List<string>();
            foreach (var i in model.geoStampedImages)
            {
                geoStampedImageLst.Add(i.fileName + "|" + i.imageType);
            }
            createDirAndImage(model.geoStampedImages);
            ViewBag.geoStampedImage = geoStampedImageLst;

            return View(model);
        }

        public ActionResult OpenReport()
        {
            ReportViewModel model = new ReportViewModel();

            model.populateReportViewModel();
            return View(model);
        }


        public void createDirAndImage(List<ImageDetails> imgList)
        {
            foreach (var i in imgList)
            {
                string dirPath = Path.Combine(@"~/InstitutionImage/" + i.imageType);
                dirPath = HttpContext.Server.MapPath(dirPath);
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
                DirectoryInfo di = Directory.CreateDirectory(dirPath);
            }

            foreach (var i in imgList)
            {
                string filePath = Path.Combine(@"~/InstitutionImage/" + i.imageType, i.fileName);
                filePath = HttpContext.Server.MapPath(filePath);

                if (!System.IO.File.Exists(filePath))
                {
                    FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);
                    fs.Write(i.imageContent, 0, i.imageContent.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }

        public void getReportDetails(ReportViewModel model)
        {

        }


        public ActionResult OpenDataVerifyPage()
        {
            return View();
        }

    }
}