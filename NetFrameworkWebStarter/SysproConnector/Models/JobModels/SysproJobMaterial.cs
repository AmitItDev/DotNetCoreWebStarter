using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysproConnector.Models.JobModels
{
    public class SysproJobMaterial
    {
        public string Job { get; set; }
        public string MaterialActionType { get; set; }
        public string NonStocked { get; set; } = "N";
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public string Warehouse { get; set; }
        public string QtyReqdType { get; set; }
        public string QtyReqd { get; set; }
        public string QtyIssued { get; set; }
        public string UnitCost { get; set; }

        public string UOM { get; set; } = "EA";
        public string OperationOffset { get; set; } = "1";
        public string Line { get; set; }
        public string SerialMethod { get; set; }
        public List<Bin> Bins { get; set; }
    }
    public class Bin
    {
        public string BinLocation { get; set; }
        public string BinQuantity { get; set; }
    }
}
