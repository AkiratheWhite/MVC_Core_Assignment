using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.MVC.AssetTracking.Models
{
    public class AssetViewModel
    {
        [Display(Name ="Asset Type")]
        public string AssetType { get; set; }
        [Display(Name = "Tag Number")]
        public string TagNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
    }
}
