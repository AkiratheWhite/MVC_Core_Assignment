using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.MVC.Domain
{
    [Table("Assets")]
    public class Asset
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AssetTypeId { get; set; }
        [Required(ErrorMessage = "Tag Number is required.")][Display(Name = "Tag Number")]
        public string TagNumber { get; set; }
        [Required(ErrorMessage = "Manufacturer is required.")]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [Required(ErrorMessage = "An asset description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The asset's Serial Number is required.")][Display(Name ="Serial Number")]
        public string SerialNumber { get; set; }
        
        //Navigation properties
        public AssetType AssetType { get; set; }
    }
}
