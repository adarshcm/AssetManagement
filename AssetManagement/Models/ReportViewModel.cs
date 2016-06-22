using AssetManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetManagement.Models
{
    public class ReportViewModel
    {
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

        [Display(Name = "Urban")]
        public string urban { get; set; }

        [Display(Name = "Rural")]
        public string rural { get; set; }

        [Display(Name = "Municipal ward No.")]
        public List<SelectListItem> municipalWardNo { get; set; }
        public string selectedMunicipalWardNo { get; set; }

        [Display(Name = "Grama Panchayat")]
        public List<SelectListItem> gramaPamchayat { get; set; }
        public string selectedGramaPanchayat { get; set; }

        [Display(Name = "Village")]
        public List<SelectListItem> village { get; set; }
        public string selectedVillage { get; set; }

        public ReportViewModel()
        {
            this.state = new List<SelectListItem>();
            this.division = new List<SelectListItem>();
            this.district = new List<SelectListItem>();
            this.taluk = new List<SelectListItem>();
            this.village = new List<SelectListItem>();
            this.gramaPamchayat = new List<SelectListItem>();
            this.municipalWardNo = new List<SelectListItem>();


        }

        public void populateReportViewModel()
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
        }


    }
}