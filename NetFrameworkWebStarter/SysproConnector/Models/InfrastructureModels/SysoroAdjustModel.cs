using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysproConnector.Models.InfrastructureModels
{
    public class SysoroAdjustModel
    {
        public int AdjustId { get; set; }
        public string Reference { get; set; }
        public string Warehouse { get; set; }
        public string StockCode { get; set; }
        public string Bin { get; set; }
        public string GlCode { get; set; }
        public decimal Qty { get; set; }
        public string Description { get; set; }
        public string Notation { get; set; } = "L2L";
    }
}
