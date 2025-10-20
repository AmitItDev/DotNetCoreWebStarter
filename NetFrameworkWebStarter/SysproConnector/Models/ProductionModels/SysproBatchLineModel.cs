using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysproConnector.Models.ProductionModels
{
    public class SysproBatchLineModel
    {
        public string StockCode { get; set; }
        public string Warehouse { get; set; }
        public string Quantity { get; set; }
        public string Reference { get; set; }
        public string Notation { get; set; }
    }
}
