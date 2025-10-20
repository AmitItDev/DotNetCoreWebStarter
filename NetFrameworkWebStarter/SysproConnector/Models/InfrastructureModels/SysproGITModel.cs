using System.Collections.Generic;

namespace SysproConnector.Models.InfrastructureModels
{
    public class SysproGITModel
    {
        public string SalesOrder { get; set; }
        public string SalesOrderLine { get; set; }
        public string GTRLine { get; set; }
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public decimal OrigQty { get; set; }
        public decimal RecQty { get; set; }
        public decimal BalQty { get; set; }
        public decimal AllQty { get; set; }
        public string TargetWarehouse { get; set; }
        public List<SysproAllocation> Allocations { get; set; }
        public ResponseModel ResponseModel { get; set; }

        ///Additional 
        public string GtrReference { get; set; }
        public string sysproModel { get; set; }
        public string SourceWarehouse { get; set; }

        public string Status { get; set; }
        public string Message { get; set; }
        public string JournalNo { get; set; }
        public string Period { get; set; }
        public string Year { get; set; }

        //Extra field for send back to source warehouse
        public string SourceBin { get; set; }
        public bool IsSendBack { get; set; }
    }
    public class SysproAllocation
    {
        public int ID { get; set; }
        public long RowIndex { get; set; }
        public string Bin { get; set; }
        public decimal Qty { get; set; }
    }

    public class SysproCreateBinModel
    {
        public string stockCode { get; set; }
        public string warehouse { get; set; }
        public string bin { get; set; }
        
    }
}
