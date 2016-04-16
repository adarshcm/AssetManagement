using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagement.Models
{
    public class ImageDetails
    {
        public string fileName { get; set; }
        public string imageType { get; set; }
        public byte[] imageContent { get; set; }
    }
}