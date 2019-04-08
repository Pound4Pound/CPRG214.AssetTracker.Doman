using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.OfficeAssets.WebInterface.Models
{
    public class AssetType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
