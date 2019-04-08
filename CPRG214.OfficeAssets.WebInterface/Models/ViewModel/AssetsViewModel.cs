using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.OfficeAssets.WebInterface.Models.ViewModel
{
    public class AssetsViewModel
    {
        public Assets Assets { get; set; }
        public IEnumerable<AssetType> AssetTypes { get; set; }


    }
}
