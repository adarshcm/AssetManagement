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
        public int assetID { get; set; }

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
        public DateTime advisoryRegDate { get; set; }

        [Display(Name = "Date of Expiry")]
        public DateTime advisoryExpDate { get; set; }

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

        [Display(Name = "Asset Status")]
        public List<SelectListItem> assetStatus { get; set; }
        public string selectedAssetStatus { get; set; }

        [Display(Name = "Institution Type")]
        public List<SelectListItem> institutionType { get; set; }
        public string selectedInstitutionType { get; set; }

        [Display(Name = "G.N. No")]
        public string gnNumber { get; set; }

        [Display(Name = "G.N. Date")]
        public DateTime gnDate { get; set; }

        [Display(Name = "C.R. No")]
        public string crNumber { get; set; }

        [Display(Name = "C.R. Date")]
        public DateTime crDate { get; set; }

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
        public DateTime managementRegDate { get; set; }

        [Display(Name = "Date of Expiry")]
        public DateTime managementExpDate { get; set; }

        public List<CommitteeDetails> managementDetails { get; set; }

        public List<ImageDetails> assetStatusImages { get; set; }



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
            this.assetStatusImages = new List<ImageDetails>();
 
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

            List<string> divisionLst = assetDal.getDivisionDetails();
            this.division = (from item in divisionLst
                          select new SelectListItem
                          {
                              Text = item,
                              Value = item
                          }).ToList();

            List<string> districtLst = assetDal.getDistrictDetails();
            this.district = (from item in districtLst
                             select new SelectListItem
                             {
                                 Text = item,
                                 Value = item
                             }).ToList();

            List<string> talukLst = assetDal.getTalukDetails();
            this.taluk = (from item in talukLst
                          select new SelectListItem
                             {
                                 Text = item,
                                 Value = item
                             }).ToList();


            List<string> MPLst = assetDal.getMPConstituency();
            this.MPConstituency = (from item in MPLst
                          select new SelectListItem
                          {
                              Text = item,
                              Value = item
                          }).ToList();

            List<string> talukPanchLst = assetDal.getTalukPanchayath();
            this.talukPanchayat = (from item in talukPanchLst
                                   select new SelectListItem
                                   {
                                       Text = item,
                                       Value = item
                                   }).ToList();

            List<string> MLALst = assetDal.getMPConstituency();
            this.MLAConstituency = (from item in MLALst
                                   select new SelectListItem
                                   {
                                       Text = item,
                                       Value = item
                                   }).ToList();


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

            List<string> mainNameLst = assetDal.getMainAssetName();
            this.mainInstitutionName = (from item in mainNameLst
                                        select new SelectListItem
                                   {
                                       Text = item,
                                       Value = item
                                   }).ToList();

        }


    }

    
}




