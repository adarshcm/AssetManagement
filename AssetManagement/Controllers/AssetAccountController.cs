using AssetManagement.DAL;
using AssetManagement.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web;
using System.IO;

namespace AssetManagement.Controllers
{
    public class AssetAccountController : Controller
    {
        AssetDetailsDAL assetDetailsDal = new AssetDetailsDAL();
        List<CommitteeDetails> managementLst = new List<CommitteeDetails>();
        List<CommitteeDetails> advisoryLst = new List<CommitteeDetails>();
        // GET: AssetAccount
        public ActionResult OpenAddAsset()
        {
            return PartialView("~/Views/AssetAccount/OpenAsset.cshtml");
        }

        public ActionResult AddAsset(string assetType)
        {
            AssetViewModels model = new AssetViewModels();
            model.assetTypeFlow = assetType;
            model.populateAssetViewModel();
            ViewBag.assetFlow = "AddAsset";
            ViewBag.managementDetails = "AddAsset";
            ViewBag.advisoryDetails = "AddAsset";
            if (assetType == "MainAsset")
            {
                return View("~/Views/AssetAccount/AddMainAsset.cshtml", model);
            }
            else
            {
                return View("~/Views/AssetAccount/AddSubAsset.cshtml", model);
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
                
                bool status = assetDetailsDal.saveInstitutionInformation(model);
                if (status)
                {
                    ViewBag.isAdmin = Session["isAdmin"];                   
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
            JArray assetDetailsLst = assetDetailsDal.getListOfAssets();
            ViewBag.data = assetDetailsLst;
            return View();
        }

        public ActionResult RemoveInstitutionsFromDB(string assetName)
        {
            assetDetailsDal.removeInstitutionFromDB(assetName);
            return View("~/Views/AssetAccount/RemoveAsset.cshtml");
        }

        public ActionResult OpenEditAsset()
        {
            JArray assetDetailsLst = assetDetailsDal.getListOfAssets();

            ViewBag.data = assetDetailsLst;
            return View("~/Views/AssetAccount/OpenEditAsset.cshtml");

        }      


        public ActionResult EditAsset(string assetName)
        {
            AssetViewModels model = new AssetViewModels();
            ViewBag.assetFlow = "EditAsset";
            model.populateAssetViewModel();

            model = assetDetailsDal.getAssetDetailsForEditFLow(assetName,model);

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
                        jobj.Add("Appointment Type", i.appointmentType);
                        jobj.Add("Appointment Date", i.appointmentDate);
                        jobj.Add("Tenure", i.tenure);

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
                        jobj.Add("Appointment Type", i.appointmentType);
                        jobj.Add("Appointment Date", i.appointmentDate);
                        jobj.Add("Tenure", i.tenure);

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

        public ActionResult AddManagementDetailsToModel(string id,string desgination,string name,int mobile,string email,string appointmentType, string appointmentDate, string tenure)
        {
            
            CommitteeDetails obj = new CommitteeDetails();
            obj.id = id;
            obj.designation = desgination;
            obj.emailID = email;
            obj.appointmentDate = appointmentDate;
            obj.appointmentType = appointmentType;
            obj.mobile = mobile;
            obj.tenure = tenure;
            obj.name = name;
            
            if(HttpContext.Session["managementLst"] == null)
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

        public ActionResult EditManagementDetailsToModel(string id,string desgination, string name, int mobile, string email, string appointmentType, string appointmentDate, string tenure)
        {

            managementLst = (List<CommitteeDetails>)HttpContext.Session["managementLst"];
            foreach(var i in managementLst)
            {
                if (i.id.Equals(id))
                {
                    i.id = id;
                    i.designation = desgination;
                    i.emailID = email;
                    i.appointmentDate = appointmentDate;
                    i.appointmentType = appointmentType;
                    i.mobile = mobile;
                    i.tenure = tenure;
                    i.name = name;

                }
            }
            HttpContext.Session["managementLst"] = managementLst;

            return View();
        }

        public ActionResult DeleteManagementDetailsToModel(string id,string desgination, string name, int mobile, string email, string appointmentType, string appointmentDate, string tenure)
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
        public ActionResult AddAdvisoryDetailsToModel(string id, string desgination, string name, int mobile, string email, string appointmentType, string appointmentDate, string tenure)
        {

            CommitteeDetails obj = new CommitteeDetails();
            obj.id = id;
            obj.designation = desgination;
            obj.emailID = email;
            obj.appointmentDate = appointmentDate;
            obj.appointmentType = appointmentType;
            obj.mobile = mobile;
            obj.tenure = tenure;
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

        public ActionResult EditAdvisoryDetailsToModel(string id, string desgination, string name, int mobile, string email, string appointmentType, string appointmentDate, string tenure)
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
                    i.appointmentType = appointmentType;
                    i.mobile = mobile;
                    i.tenure = tenure;
                    i.name = name;

                }
            }
            HttpContext.Session["advisoryLst"] = advisoryLst;

            return View();
        }

        public ActionResult DeleteAdvisoryDetailsToModel(string id, string desgination, string name, int mobile, string email, string appointmentType, string appointmentDate, string tenure)
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

        public ActionResult OpenAssetStatusUpload()
        {
            return PartialView("~/Views/AssetAccount/PartialOpenAssetStatusUpload.cshtml");
        }



    }
}