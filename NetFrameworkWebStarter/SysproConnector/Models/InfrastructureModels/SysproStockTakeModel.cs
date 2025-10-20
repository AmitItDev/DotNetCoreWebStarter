using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysproConnector.Models.InfrastructureModels
{
    public class SysproStockTakeModel
    {
        public string StockCode { get; set; }
        public string Description { get; set; }
        public decimal OrigQtyOnHand { get; set; }
        public string Bin { get; set; }
        public string Warehouse { get; set; }
        public decimal Counted { get; set; }
        public decimal Variance { get; set; }

        ///Additional
        public string Reference { get; set; }
        public ResponseModel ResponseModel { get; set; }
    }
}
