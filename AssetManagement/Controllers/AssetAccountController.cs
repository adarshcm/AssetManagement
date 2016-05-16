using AssetManagement.DAL;
using AssetManagement.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web;
using System.IO;
using System.Linq;
using System.Globalization;

namespace AssetManagement.Controllers
{
    public class AssetAccountController : Controller
    {
        AssetDetailsDAL assetDetailsDal = new AssetDetailsDAL();
        List<CommitteeDetails> managementLst = new List<CommitteeDetails>();
        List<CommitteeDetails> advisoryLst = new List<CommitteeDetails>();
        // GET: AssetAccount

        public ActionResult OpenAccountPage()
        {
            assetDetailsDal.setSessionToNull();
            ViewBag.login = "Logout";
            ViewBag.isAdmin = "admin";
            return View("~/Views/LoginReg/OpenAccountPage.cshtml");
        }
        public ActionResult OpenAddAsset()
        {
            ViewBag.login = "Logout";
            return PartialView("~/Views/AssetAccount/OpenAsset.cshtml");
        }

        public ActionResult AddAsset(string assetType)
        {
            assetDetailsDal.setSessionToNull();
            ViewBag.login = "Logout";
            AssetViewModels model = new AssetViewModels();

            model.populateAssetViewModel();
            model.assetTypeFlow = assetType;
            ViewBag.assetFlow = "AddAsset";
            ViewBag.managementDetails = "AddAsset";
            ViewBag.advisoryDetails = "AddAsset";
            if (assetType == "MainAsset")
            {
                return View("~/Views/AssetAccount/AddMainAsset.cshtml", model);
            }
            else
            {
                Dictionary<string, string> list = assetDetailsDal.getMainAssetName();

                if (list.Count != 0)
                {
                    return View("~/Views/AssetAccount/AddSubAsset.cshtml", model);
                }
                else
                {
                    ViewBag.isAdmin = HttpContext.Session["isAdmin"];
                    ViewBag.isException = "set";
                    return View("~/Views/LoginReg/OpenAccountPage.cshtml");
                }

            }
        }

        public ActionResult AddManagementDetails()
        {

            return PartialView("~/Views/AssetAccount/PartialAddManagementDetails.cshtml");
        }

        public ActionResult SaveAssetInformtaion(AssetViewModels model)
        {
            try
            {
                foreach (var i in model.selectedAssetTypeList)
                {

                    model.selectedAssetType += i + "|";
                }
                ViewBag.login = "Logout";

                //get the value of the selected radio button and assign it to model

                if (model.rdBtnType == "rural")
                {
                    model.rural = model.rdBtnType;
                }
                else
                {
                    model.urban = model.rdBtnType;
                }
                bool status = assetDetailsDal.saveInstitutionInformation(model);
                assetDetailsDal.setSessionToNull();
                if (status)
                {
                    ViewBag.isAdmin = HttpContext.Session["isAdmin"];
                    return View("~/Views/LoginReg/OpenAccountPage.cshtml");
                }
                else
                {
                    return View("~/Views/LoginReg/OpenAccountPage.cshtml");
                }

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public ActionResult RemoveAsset()
        {
            ViewBag.login = "Logout";
            JArray assetDetailsLst = assetDetailsDal.getListOfAssets();
            ViewBag.data = assetDetailsLst;
            return View();
        }

        public ActionResult RemoveInstitutionsFromDB(string institutionId)
        {
            ViewBag.login = "Logout";
            assetDetailsDal.removeInstitutionFromDB(institutionId);
            return View("~/Views/AssetAccount/RemoveAsset.cshtml");
        }

        public ActionResult OpenEditAsset()
        {
            ViewBag.login = "Logout";
            JArray assetDetailsLst = assetDetailsDal.getListOfAssets();

            ViewBag.data = assetDetailsLst;
            return View("~/Views/AssetAccount/OpenEditAsset.cshtml");

        }


        public ActionResult EditAsset(string institutionId)
        {
            ViewBag.login = "Logout";
            AssetViewModels model = new AssetViewModels();
            ViewBag.assetFlow = "EditAsset";
            model.populateAssetViewModel();

            model = assetDetailsDal.getAssetDetailsForEditFLow(institutionId, model);

            if(model.selectedDivision != null)
            {
                List<string> distLst = assetDetailsDal.getDistrict(model.selectedDivision);
                model.district = (from item in distLst
                                  select new SelectListItem
                                  {
                                      Text = item,
                                      Value = item
                                  }).ToList();
            }
            
            if(model.selectedDistrict != null)
            {
                List<string> talukLst = assetDetailsDal.getTaluk(model.selectedDistrict);
                model.taluk = (from item in talukLst
                               select new SelectListItem
                               {
                                   Text = item,
                                   Value = item
                               }).ToList();


                List<string> mpLst = assetDetailsDal.getMPList(model.selectedDistrict);
                model.MPConstituency = (from item in mpLst
                               select new SelectListItem
                               {
                                   Text = item,
                                   Value = item
                               }).ToList();

                List<string> mlaLst = assetDetailsDal.getMLAList(model.selectedDistrict);
                model.MLAConstituency = (from item in mlaLst
                                        select new SelectListItem
                                        {
                                            Text = item,
                                            Value = item
                                        }).ToList();






            }
            
            if(model.selectedTalukPanchayat != null)
            {
                List<string> tempLst = new List<string>();
                tempLst.Add(model.selectedTalukPanchayat);
                List<string> talukPLst = tempLst;
                model.talukPanchayat = (from item in talukPLst
                                        select new SelectListItem
                                        {
                                            Text = item,
                                            Value = item
                                        }).ToList();
            }


            if (model.selectedTalukPanchayat != null) {
                List<string> villagePanchayathLst = assetDetailsDal.getVillagePanchayath(model.selectedTalukPanchayat);
                model.gramaPamchayat = (from item in villagePanchayathLst
                                        select new SelectListItem
                                        {
                                            Text = item,
                                            Value = item
                                        }).ToList();
            }

            if(model.selectedGramaPanchayat != null)
            {
                List<string> villageLst = assetDetailsDal.getVillage(model.selectedGramaPanchayat);
                model.village = (from item in villageLst
                                 select new SelectListItem
                                 {
                                     Text = item,
                                     Value = item
                                 }).ToList();
            }


            Char delimiter = '|';

            if (model.selectedAssetType != null)
            {

                String[] words = model.selectedAssetType.Split(delimiter);

                foreach (var i in words)
                {
                    if (i != "")
                    {
                        model.selectedAssetTypeList.Add(i);
                    }
                }
            }

            List<string> assetStatusImageLst = new List<string>();
            foreach (var i in model.assetStatusImages)
            {
                assetStatusImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.assetStatusImageLst = assetStatusImageLst;

            List<string> gnNumberImageLst = new List<string>();
            foreach (var i in model.gnNumberImages)
            {
                gnNumberImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.gnNumberImageLst = gnNumberImageLst;

            List<string> crNumberImageLst = new List<string>();
            foreach (var i in model.crNumberImages)
            {
                crNumberImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.crNumberImageLst = crNumberImageLst;

            List<string> courtOrderImageLst = new List<string>();
            foreach (var i in model.courtOrderImages)
            {
                courtOrderImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.courtOrderImageLst = courtOrderImageLst;

            List<string> surveyNoImageLst = new List<string>();
            foreach (var i in model.surveyNoImages)
            {
                surveyNoImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.surveyNoImageLst = surveyNoImageLst;

            List<string> khathaNoImageLst = new List<string>();
            foreach (var i in model.khathaNoImages)
            {
                khathaNoImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.khathaNoImageLst = khathaNoImageLst;

            List<string> municipalNoImageLst = new List<string>();
            foreach (var i in model.municipalNoImages)
            {
                municipalNoImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.municipalNoImageLst = municipalNoImageLst;

            List<string> northImageLst = new List<string>();
            foreach (var i in model.northImages)
            {
                northImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.northImageLst = northImageLst;

            List<string> eastImageLst = new List<string>();
            foreach (var i in model.eastImages)
            {
                eastImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.eastImageLst = eastImageLst;

            List<string> southImageLst = new List<string>();
            foreach (var i in model.southImages)
            {
                southImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.southImageLst = southImageLst;

            List<string> westImageLst = new List<string>();
            foreach (var i in model.westImages)
            {
                westImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.westImageLst = westImageLst;

            List<string> estimatedValueImageLst = new List<string>();
            foreach (var i in model.estimatedValueImages)
            {
                estimatedValueImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.estimatedValueImageLst = estimatedValueImageLst;

            List<string> litigationManagementImageLst = new List<string>();
            foreach (var i in model.litigationManagementImages)
            {
                litigationManagementImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.litigationManagementImageLst = litigationManagementImageLst;

            List<string> litigationAssetImageLst = new List<string>();
            foreach (var i in model.litigationAssetImages)
            {
                litigationAssetImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.litigationAssetImageLst = litigationAssetImageLst;

            List<string> geoStampedImageLst = new List<string>();
            foreach (var i in model.geoStampedImages)
            {
                geoStampedImageLst.Add(i.fileName + "|" + i.imageSize);
            }
            ViewBag.geoStampedImageLst = geoStampedImageLst;


            if (model.assetTypeFlow == "MainAsset")
            {


                if (model.managementDetails != null)
                {
                    int count = 1;
                    JArray jarray = new JArray();
                    foreach (var i in model.managementDetails)
                    {
                        JObject jobj = new JObject();
                        jobj.Add("ID", count);
                        jobj.Add("Designation", i.designation);
                        jobj.Add("Name", i.name);
                        jobj.Add("Mobile No", i.mobile);
                        jobj.Add("E-mail Id", i.emailID);
                        DateTime dt = DateTime.ParseExact(i.appointmentDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        jobj.Add("Appointment Date", dt);
                        jobj.Add("Image", i.imageName);

                        jarray.Add(jobj);
                        count++;
                    }

                    ViewBag.managementDetails = jarray;
                }
                else
                {
                    JArray jarray = new JArray();
                    ViewBag.managementDetails = jarray;
                }

                if (model.advisoryDetails != null)
                {
                    int count = 1;
                    JArray jarray = new JArray();
                    foreach (var i in model.advisoryDetails)
                    {
                        JObject jobj = new JObject();
                        jobj.Add("ID", count);
                        jobj.Add("Designation", i.designation);
                        jobj.Add("Name", i.name);
                        jobj.Add("Mobile No", i.mobile);
                        jobj.Add("E-mail Id", i.emailID);
                        DateTime dt = DateTime.ParseExact(i.appointmentDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        jobj.Add("Appointment Date", dt);
                        jobj.Add("Image", i.imageName);

                        jarray.Add(jobj);
                        count++;
                    }

                    ViewBag.advisoryDetails = jarray;
                }
                else
                {
                    JArray jarray = new JArray();
                    ViewBag.advisoryDetails = jarray;
                }


                return View("~/Views/AssetAccount/AddMainAsset.cshtml", model);
            }
            else
            {
                return View("~/Views/AssetAccount/AddSubAsset.cshtml", model);
            }

        }

        public ActionResult AddManagementDetailsToModel(string id, string desgination, string name, int mobile, string email, string appointmentDate, string image)
        {

            CommitteeDetails obj = new CommitteeDetails();
            obj.id = id;
            obj.designation = desgination;
            obj.emailID = email;
            obj.appointmentDate = appointmentDate;
            obj.mobile = mobile;
            obj.image = (ImageDetails)HttpContext.Session["managementImageLst"];
            obj.name = name;
            obj.imageName = image;

            if (HttpContext.Session["managementLst"] == null)
            {
                managementLst.Add(obj);
            }
            else
            {
                managementLst = (List<CommitteeDetails>)HttpContext.Session["managementLst"];
                managementLst.Add(obj);
            }

            HttpContext.Session["managementLst"] = managementLst;
            return View();
        }

        public ActionResult EditManagementDetailsToModel(string id, string desgination, string name, int mobile, string email, string appointmentDate, string image)
        {

            managementLst = (List<CommitteeDetails>)HttpContext.Session["managementLst"];
            foreach (var i in managementLst)
            {
                if (i.id.Equals(id))
                {
                    i.id = id;
                    i.designation = desgination;
                    i.emailID = email;
                    i.appointmentDate = appointmentDate;
                    i.mobile = mobile;
                    i.name = name;
                    i.imageName = image;

                    if(i.image != null)
                    {
                        if (image == i.image.fileName)
                        {
                            i.image = i.image;
                        }
                        else
                        {
                            i.image = (ImageDetails)HttpContext.Session["managementImageLst"];
                        }
                    }
                    
                }
            }
            HttpContext.Session["managementLst"] = managementLst;

            return View();
        }

        public ActionResult DeleteManagementDetailsToModel(string id, string desgination, string name, int mobile, string email, string appointmentDate, string image)
        {
            managementLst = (List<CommitteeDetails>)HttpContext.Session["managementLst"];
            foreach (var i in managementLst)
            {
                if (i.id.Equals(id))
                {
                    managementLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["managementLst"] = managementLst;
            return View();
        }


        public ActionResult AddAdvisoryDetailsToModel(string id, string desgination, string name, int mobile, string email, string appointmentDate, string image)
        {

            CommitteeDetails obj = new CommitteeDetails();
            obj.id = id;
            obj.designation = desgination;
            obj.emailID = email;
            obj.appointmentDate = appointmentDate;
            obj.mobile = mobile;
            obj.image = (ImageDetails)HttpContext.Session["advisoryImageLst"];
            obj.imageName = image;
            obj.name = name;

            if (HttpContext.Session["advisoryLst"] == null)
            {
                advisoryLst.Add(obj);
            }
            else
            {
                advisoryLst = (List<CommitteeDetails>)HttpContext.Session["advisoryLst"];
                advisoryLst.Add(obj);
            }

            HttpContext.Session["advisoryLst"] = advisoryLst;
            return View();
        }

        public ActionResult EditAdvisoryDetailsToModel(string id, string desgination, string name, int mobile, string email, string appointmentDate, string image)
        {

            advisoryLst = (List<CommitteeDetails>)HttpContext.Session["advisoryLst"];
            foreach (var i in advisoryLst)
            {
                if (i.id.Equals(id))
                {
                    i.id = id;
                    i.designation = desgination;
                    i.emailID = email;
                    i.appointmentDate = appointmentDate;
                    i.mobile = mobile;
                    i.imageName = image;
                    i.name = name;
                    if(i.image != null)
                    {
                        if (image == i.image.fileName)
                        {
                            i.image = i.image;
                        }
                        else
                        {
                            i.image = (ImageDetails)HttpContext.Session["advisoryImageLst"];
                        }
                    }
                    

                }
            }
            HttpContext.Session["advisoryLst"] = advisoryLst;

            return View();
        }

        public ActionResult DeleteAdvisoryDetailsToModel(string id, string desgination, string name, int mobile, string email, string appointmentDate, string image)
        {
            advisoryLst = (List<CommitteeDetails>)HttpContext.Session["advisoryLst"];
            foreach (var i in advisoryLst)
            {
                if (i.id.Equals(id))
                {
                    advisoryLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["advisoryLst"] = advisoryLst;
            return View();
        }

        public ActionResult GetVillage(string gramaPanchayat)
        {
            List<string> villagelst = assetDetailsDal.getVillage(gramaPanchayat);
            return Json(new { result = villagelst });
        }

        [HttpPost]
        public ActionResult GetMainInstitutionList()
        {
            Dictionary<string, string> list = assetDetailsDal.getMainAssetName();
            return Json(new { result = list });
        }

        public ActionResult GetDistrict(string division)
        {
            List<string> districtlst = assetDetailsDal.getDistrict(division);
            return Json(new { result = districtlst });
        }

        public ActionResult GetTaluk(string district)
        {
            List<string> taluklst = assetDetailsDal.getTaluk(district);
            return Json(new { result = taluklst });
        }

        public ActionResult GetGramaPanchayath(string talukP)
        {
            List<string> talukPlst = assetDetailsDal.getVillagePanchayath(talukP);
            return Json(new { result = talukPlst });
        }

        public ActionResult GetTalukPanchayath(string taluk)
        {
            List<string> taluklst = assetDetailsDal.getTalukPanchayath(taluk);
            return Json(new { result = taluklst });
        }

        public ActionResult GetMPList(string district)
        {
            List<string> mplst = assetDetailsDal.getMPList(district);
            return Json(new { result = mplst });
        }

        public ActionResult GetMLAList(string district)
        {
            List<string> mlalst = assetDetailsDal.getMLAList(district);
            return Json(new { result = mlalst });
        }

        public ActionResult checkForInstiutionId(string institutionId)
        {
            string status = assetDetailsDal.checkForInstiutionId(institutionId);
            return Json(new { result = status });
        }

        [HttpPost]
        public ActionResult OpenTestGallery()
        {
            ViewBag.login = "Logout";
            AssetViewModels model = new AssetViewModels();
            ViewBag.assetFlow = "EditAsset";
            model.populateAssetViewModel();

            model = assetDetailsDal.getAssetDetailsForEditFLow("KAMYSMYSHUNHUNASPBAL00001", model);
            createDirAndImage(model.assetStatusImages);
            createDirAndImage(model.gnNumberImages);

            return PartialView("~/Views/AssetAccount/PartialOpenTestGallery.cshtml"); ;
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

                FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);
                fs.Write(i.imageContent, 0, i.imageContent.Length);
                fs.Flush();
                fs.Close();
            }
        }

    }

    
}