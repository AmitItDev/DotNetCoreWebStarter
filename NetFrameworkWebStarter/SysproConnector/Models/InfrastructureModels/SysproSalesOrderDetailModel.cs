using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysproConnector.Models.InfrastructureModels
{
    public class SysproSalesOrderDetailModel
    {
        public string SalesOrder { get; set; }
        public string MStockCode { get; set; }
        public string MStockDes { get; set; }
        public decimal MOrderQty { get; set; }
        public decimal SalesOrderLine { get; set; }
        public string MWarehouse { get; set; }
        public string MBin { get; set; }
    }
}
