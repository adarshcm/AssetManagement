using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AssetManagement.Models
{
    public class CommitteeDetails
    {
        public string id { get; set; }

        [Display(Name = "Designation")]
        //public List<SelectListItem> designation { get; set; }
        public string designation { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Mobile")]
        public int mobile { get; set; }

        [Display(Name = "Email ID")]
        public string emailID { get; set; }

        [Display(Name = "Appointment Type")]
        //public List<SelectListItem> appointmentType { get; set; }
        public string appointmentType { get; set; }

        [Display(Name = "Appointment Date")]
        public string appointmentDate { get; set; }

        [Display(Name = "Tenure")]
        public string tenure { get; set; }


    }
}