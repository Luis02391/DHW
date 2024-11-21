using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLDaraWarehouse.Entities.DWH
{
    public class DimShipper
    {
        public int ShipperID { get; set; }
        public string? ShipperName { get; set; }
        public string? Phone { get; set; }

    }

}
