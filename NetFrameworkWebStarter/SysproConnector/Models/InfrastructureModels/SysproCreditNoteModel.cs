using System;

namespace SysproConnector.Models.InfrastructureModels
{
    public class SysproCreditNoteHeaderModel
    {
        public string Customer { get; set; }

        public string CustomerPoNumber { get; set; }

        public DateTime CreditNoteDate { get; set; }
    }

    public class SysproCreditNoteLineModel
    {
        public string CreditNoteNumber { get; set; }

        public string CreditReason { get; set; }

        public string StockCode { get; set; }

        public string Warehouse { get; set; }

        public decimal OrderQty { get; set; }

        public string OrderUom { get; set; }

        public SysproCreditNoteBinModel Bins { get; set; }

        public DateTime CustRequestDate { get; set; }

    }

    public class SysproCreditNoteBinModel
    {
        public string BinLocation { get; set; }

        public decimal BinQuantity { get; set; }
    }

    public class SysproCreditOrderResponse
    {

    }
}
