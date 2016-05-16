using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AssetManagement.DAL;

namespace AssetManagement.Models
{
    public class AssetViewModels
    {
        public string sel { get; set; }

        public string rdBtnType { get; set; }

        [Display(Name = "Institution ID")]
        public string assetID { get; set; }

        public string assetTypeFlow { get; set; }

        [Display(Name = "Main Institution name")]
        public List<SelectListItem> mainInstitutionName { get; set; }
        public string selectedMainInstitutionName { get; set; }

        // location details
        [Display(Name = "State")]
        public List<SelectListItem> state { get; set; }
        public string selectedState { get; set; }

        [Display(Name = "Division")]
        public List<SelectListItem> division { get; set; }
        public string selectedDivision { get; set; }

        [Display(Name = "Taluk")]
        public List<SelectListItem> taluk { get; set; }
        public string selectedTaluk { get; set; }

        [Display(Name = "District")]
        public List<SelectListItem> district { get; set; }
        public string selectedDistrict { get; set; }


        [Display(Name = "MP Constituency")]
        public List<SelectListItem> MPConstituency { get; set; }
        public string selectedMPConstituency { get; set; }
        
        [Display(Name = "MLA Constituency")]
        public List<SelectListItem> MLAConstituency { get; set; }
        public string selectedMLAConstituency { get; set; }
      

        [Display(Name = "Urban")]
        public string urban { get; set; }

        [Display(Name = "Rural")]
        public string rural { get; set; }

        [Display(Name = "Municipal ward No.")]
        public List<SelectListItem> municipalWardNo { get; set; }
        public string selectedMunicipalWardNo { get; set; }

        [Display(Name = "Taluk Panchayat")]
        public List<SelectListItem> talukPanchayat { get; set; }
        public string selectedTalukPanchayat { get; set; }

        [Display(Name = "Grama Panchayat")]
        public List<SelectListItem> gramaPamchayat { get; set; }
        public string selectedGramaPanchayat { get; set; }

        [Display(Name = "Village")]
        public List<SelectListItem> village { get; set; }
        public string selectedVillage { get; set; }

        [Display(Name = "Latitude")]
        public double latitude { get; set; }

        [Display(Name = "Longitude")]
        public double longitude { get; set; }


        //advisory details
        [Display(Name = "Trust/Society Name")]
        public string advisorySocietyName { get; set; }

        [Display(Name = "Approval No")]
        public string advisoryApprovalNumber { get; set; }

        [Display(Name = "Registration/Order No")]
        public string advisoryRegNumber { get; set; }

        [Display(Name = "Date of Registration")]
        public string advisoryRegDate { get; set; }

        [Display(Name = "Date of Expiry")]
        public string advisoryExpDate { get; set; }

        [Display(Name = "Appointment Type")]
        public List<SelectListItem> advisoryAppointmentType { get; set; }
        public string selectedAdvisoryAppointmentType { get; set; }

        [Display(Name = "Tenure")]
        public string advisoryTenure { get; set; }

        public List<CommitteeDetails> advisoryDetails { get; set; }
        
        // assest details
        [Display(Name = "Institution Name")]
        public string institutionName { get; set; }

        [Display(Name = "Asset Name")]
        public string assetName { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Asset Type")]
        public List<SelectListItem> assetType { get; set; }
        public string selectedAssetType { get; set; }
        public List<string> selectedAssetTypeList { get; set; }

        [Display(Name = "Asset Status")]
        public List<SelectListItem> assetStatus { get; set; }
        public string selectedAssetStatus { get; set; }

        [Display(Name = "Institution Type")]
        public List<SelectListItem> institutionType { get; set; }
        public string selectedInstitutionType { get; set; }

        [Display(Name = "G.N. No")]
        public string gnNumber { get; set; }

        [Display(Name = "G.N. Date")]
        public string gnDate { get; set; }

        [Display(Name = "C.R. No")]
        public string crNumber { get; set; }

        [Display(Name = "C.R. Date")]
        public string crDate { get; set; }

        [Display(Name = "Classification")]
        public List<SelectListItem> classificationType { get; set; }
        public string selectedClassificationType { get; set; }

        [Display(Name = "Court Judgement Order")]
        public string courtJudgementOrder { get; set; }

        [Display(Name = "Waqf ID")]
        public string waqfID { get; set; }

        [Display(Name = "WAMSI Code")]
        public string wamsiCode { get; set; }


        //property details
        [Display(Name = "Survey Number")]
        public string surveyNo { get; set; }

        [Display(Name = "Khatha Number")]
        public string khathaNo { get; set; }

        [Display(Name = "Municipal Number")]
        public string municipalNo { get; set; }

        [Display(Name = "North")]
        public string north { get; set; }

        [Display(Name = "East")]
        public string east { get; set; }

        [Display(Name = "South")]
        public string south { get; set; }

        [Display(Name = "West")]
        public string west { get; set; }

        [Display(Name = "Estimated Value")]
        public string estimatedValue { get; set; }

        [Display(Name = "Property ID")]
        public string propertyID { get; set; }

        [Display(Name = "Litigation related to management")]
        public string litigationManagement { get; set; }

        [Display(Name = "Litigation related to assets")]
        public string litigationAsset { get; set; }

        [Display(Name = "North to South")]
        public string northToSouth { get; set; }

        [Display(Name = "East to West")]
        public string eastToWest { get; set; }

        [Display(Name = "Total")]
        public string total { get; set; }

        //Management details
        [Display(Name = "Management Type")]
        public List<SelectListItem> managementType { get; set; }
        public string selectedManagementType { get; set; }

        [Display(Name = "Trust/Society Name")]
        public string managementSocietyName { get; set; }

        [Display(Name = "Approval No")]
        public string managementApprovalNumber { get; set; }

        [Display(Name = "Registration/Order No")]
        public string managementRegNumber { get; set; }

        [Display(Name = "Date of Registration")]
        public string managementRegDate { get; set; }

        [Display(Name = "Date of Expiry")]
        public string managementExpDate { get; set; }

        [Display(Name = "Appointment Type")]
        public List<SelectListItem> managementAppointmentType { get; set; }
        public string selectedManagementAppointmentType { get; set; }

        [Display(Name = "Tenure")]
        public string managementTenure { get; set; }

        public List<CommitteeDetails> managementDetails { get; set; }

        public List<ImageDetails> assetStatusImages { get; set; }
        public List<ImageDetails> gnNumberImages { get; set; }
        public List<ImageDetails> crNumberImages { get; set; }
        public List<ImageDetails> courtOrderImages { get; set; }
        public List<ImageDetails> surveyNoImages { get; set; }
        public List<ImageDetails> khathaNoImages { get; set; }
        public List<ImageDetails> municipalNoImages { get; set; }
        public List<ImageDetails> northImages { get; set; }
        public List<ImageDetails> eastImages { get; set; }
        public List<ImageDetails> southImages { get; set; }
        public List<ImageDetails> westImages { get; set; }
        public List<ImageDetails> estimatedValueImages { get; set; }
        public List<ImageDetails> litigationManagementImages { get; set; }
        public List<ImageDetails> litigationAssetImages { get; set; }
        public List<ImageDetails> geoStampedImages { get; set; }
        

        public AssetViewModels()
        {
            this.state = new List<SelectListItem>();
            this.division = new List<SelectListItem>();
            this.district = new List<SelectListItem>();
            this.taluk = new List<SelectListItem>();
            this.village = new List<SelectListItem>();
            this.talukPanchayat = new List<SelectListItem>();
            this.gramaPamchayat = new List<SelectListItem>();
            this.municipalWardNo = new List<SelectListItem>();
            this.MPConstituency = new List<SelectListItem>();
            this.MLAConstituency = new List<SelectListItem>();


            this.assetType = new List<SelectListItem>();
            this.assetStatus = new List<SelectListItem>();
            this.institutionType = new List<SelectListItem>();
            this.classificationType = new List<SelectListItem>();

            this.advisoryDetails = new List<CommitteeDetails>();
            this.managementType = new List<SelectListItem>();
            this.mainInstitutionName = new List<SelectListItem>();
            this.managementDetails = new List<CommitteeDetails>();
            this.managementAppointmentType = new List<SelectListItem>();
            this.advisoryAppointmentType = new List<SelectListItem>();

            this.assetStatusImages = new List<ImageDetails>();
            this.gnNumberImages = new List<ImageDetails>();
            this.crNumberImages = new List<ImageDetails>();
            this.courtOrderImages = new List<ImageDetails>();
            this.surveyNoImages = new List<ImageDetails>();
            this.khathaNoImages = new List<ImageDetails>();
            this.municipalNoImages = new List<ImageDetails>();
            this.northImages = new List<ImageDetails>();
            this.southImages = new List<ImageDetails>();
            this.eastImages = new List<ImageDetails>();
            this.westImages = new List<ImageDetails>();
            this.litigationAssetImages = new List<ImageDetails>();
            this.litigationManagementImages = new List<ImageDetails>();
            this.geoStampedImages = new List<ImageDetails>();
            this.estimatedValueImages = new List<ImageDetails>();
            this.selectedAssetTypeList = new List<string>();

        }

        public void populateAssetViewModel()
        {
            
            AssetDetailsDAL assetDal = new AssetDetailsDAL();
            
            List<string> stateLst = assetDal.getStateDetails();
            this.state = (from item in stateLst
                          select new SelectListItem
                         {
                             Text = item,
                             Value = item
                         }).ToList();

            List<string> divisionLst = assetDal.getDivision("Karnataka");
            this.division = (from item in divisionLst
                          select new SelectListItem
                          {
                              Text = item,
                              Value = item
                          }).ToList();        


            //List<string> MPLst = assetDal.getMPConstituency();
            //this.MPConstituency = (from item in MPLst
            //              select new SelectListItem
            //              {
            //                  Text = item,
            //                  Value = item
            //              }).ToList();

            //List<string> talukPanchLst = assetDal.getTalukPanchayath();
            //this.talukPanchayat = (from item in talukPanchLst
            //                       select new SelectListItem
            //                       {
            //                           Text = item,
            //                           Value = item
            //                       }).ToList();

            //List<string> villagePanchLst = assetDal.getVillagePanchayath();
            //this.gramaPamchayat = (from item in villagePanchLst
            //                       select new SelectListItem
            //                       {
            //                           Text = item,
            //                           Value = item
            //                       }).ToList();

            //List<string> MLALst = assetDal.getMLAConstituency();
            //this.MLAConstituency = (from item in MLALst
            //                       select new SelectListItem
            //                       {
            //                           Text = item,
            //                           Value = item
            //                       }).ToList();


            List<string> assetTypeLst = assetDal.getAssetType();
            this.assetType = (from item in assetTypeLst
                          select new SelectListItem
                          {
                              Text = item,
                              Value = item
                          }).ToList();

            List<string> assetStatusLst = assetDal.getAssetStatus();
            this.assetStatus = (from item in assetStatusLst
                              select new SelectListItem
                              {
                                  Text = item,
                                  Value = item
                              }).ToList();

            List<string> institutionLst = assetDal.getInstitutionType();
            this.institutionType = (from item in institutionLst
                                select new SelectListItem
                                {
                                    Text = item,
                                    Value = item
                                }).ToList();

            List<string> classificationLst = assetDal.getClassification();
            this.classificationType = (from item in classificationLst
                                    select new SelectListItem
                                    {
                                        Text = item,
                                        Value = item
                                    }).ToList();

            List<string> managementTypeLst = assetDal.getManagementType();
            this.managementType = (from item in managementTypeLst
                                       select new SelectListItem
                                       {
                                           Text = item,
                                           Value = item
                                       }).ToList();

            List<string> managementAppointmentLst = assetDal.getManagementAppointmentType();
            this.managementAppointmentType = (from item in managementAppointmentLst
                                   select new SelectListItem
                                   {
                                       Text = item,
                                       Value = item
                                   }).ToList();

            List<string> advisoryAppointmentLst = assetDal.getAdvisoryAppointmentType();
            this.advisoryAppointmentType = (from item in advisoryAppointmentLst
                                              select new SelectListItem
                                              {
                                                  Text = item,
                                                  Value = item
                                              }).ToList();


        }


    }

    
}





