using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysproConnector.Models.JobModels
{
    public class SysproJobQuote
    {
        public string Job { get; set; }
        public string Quantity { get; set; } = "1";
        public string Complete { get; set; } = "N";
        public string SalesOrderLink { get; set; } = "C";
        public string BillingMethod { get; set; } = "L";
        public string CostBasis { get; set; } = "T";
        public string WipValueBasis { get; set; } = "W";
        public string OrderHeader_CustomerName { get; set; }
        public string OrderHeader_ShipAddress1 { get; set; }
        public string OrderHeader_ShipAddress2 { get; set; }
        public string OrderHeader_ShipAddress3 { get; set; }
        public string OrderHeader_ShipAddress4 { get; set; }
        public string OrderHeader_ShipAddress5 { get; set; }


        public string OrderDetails_StockDescription { get; set; }
        public string OrderDetails_ProductClass { get; set; } = "BAM";
        public string OrderDetails_OperationProductClass { get; set; } = "BAM";
        public string QuantityTime { get; set; }
        public string UnitPrice { get; set; }
        public string LedgerCode { get; set; }
        public string LedgerAmount { get; set; }
        public string OrderValue { get; set; }
        public string SalesOrder { get; set; }
        public bool? UnderWarranty { get; set; }
    }
}
