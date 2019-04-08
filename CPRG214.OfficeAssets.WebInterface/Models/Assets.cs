using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.OfficeAssets.WebInterface.Models
{
    public class Assets
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tag Number")]
        public string TagNumber { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        [Display(Name="Asset Type")]
        public int AssetTypeId { get; set; }
        [ForeignKey("AssetTypeId"), Display(Name = "Asset Type")]
        public virtual AssetType AssetTypes { get; set; } 

    }
}
