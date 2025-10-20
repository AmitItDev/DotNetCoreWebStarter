using System.Collections.Generic;

namespace SysproConnector.Models.InfrastructureModels
{
    public class SysproOrderModel_Old
    {
        public string PurchaseOrder { get; set; }

        public string PurchaseOrderLine { get; set; }

        public decimal Quantity { get; set; }

        public string DelivaryNote { get; set; }

        public string GRNNumber { get; set; }
        public string SalesOrder_D { get; set; }
        public string InvoiceType { get; set; }
        public string Invoice_1 { get; set; }
    }

    public class SysproCreditNoteModel
    {
        public string SalesOrder_D { get; set; }
        public string Invoice_D { get; set; }
        public string CreditReason { get; set; }
        public List<string> LineNumber { get; set; } = new List<string>();
    }
}
