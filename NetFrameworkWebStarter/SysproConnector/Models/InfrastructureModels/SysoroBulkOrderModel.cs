using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysproConnector.Models.InfrastructureModels
{
    public class SysoroBulkOrderModel
    {
        public long BulkOrderId { get; set; }
        public string OrderActionType { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyPassword { get; set; }
        public string Customer { get; set; }
        public string CustomerName { get; set; }
        public string Warehouse { get; set; }
        public string PONumber { get; set; }
        public List<SysproBulkOrderDetailModel> sysproBulkOrderDetailModels { get; set; }
    }

    public class SysproBulkOrderDetailModel
    {
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public int Qty { get; set; }
        public int QtyAvailable { get; set; }
        public decimal Price { get; set; }
        public decimal SysproPrice { get; set; }
        public string LineActionType { get; set; }
        public string OrderUom { get; set; }
    }
}
