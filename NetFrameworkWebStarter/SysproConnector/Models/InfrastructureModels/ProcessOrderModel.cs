using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysproConnector.Models.InfrastructureModels
{
    public class ProcessOrder
    {
        public ProcessOrder()
        {
            OrderHeaders = new ProcessOrderHeaders();
            OrderDetails = new ProcessOrderDetails();
        }
        public ProcessOrderHeaders OrderHeaders { get; set; }
        public ProcessOrderDetails OrderDetails { get; set; }
    }

    public class ProcessOrderHeaders
    {
        public string GrnNumber { get; set; }
        public int Supplier { get; set; }
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public string Warehouse { get; set; }
        public decimal GrnValue { get; set; }
        public string SupplierDeliveryNote { get; set; }
        public string DebitLedgerCode { get; set; }
        public string DebitLedgerPassword { get; set; }
        public string NmDescription { get; set; }
        public string Reference { get; set; }
    }
    public class ProcessOrderDetails
    {
        public ProcessOrderDetails()
        {
            AnalysisLines = new List<AnalysisLines>();
        }

        public List<AnalysisLines> AnalysisLines { get; set; }
    }

    public class AnalysisLines
    {
        public string AnalysisCode1 { get; set; }
        public string AnalysisCode2 { get; set; }
        public string AnalysisCode3 { get; set; }
        public string AnalysisCode4 { get; set; }
        public string AnalysisCode5 { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal EntryAmount { get; set; }
        public string Comment { get; set; }
    }


}
